using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private int speed;

    private int[] speedArray = { 20, 25, 40, 50, 100, 125 };


    private byte state; // 0 stop, 1 select, 2 move

    private Vector3 dir;
    private Vector3 dirFuture;

    private bool isDead;

    public GameObject resetBtn;
    public Text scoreText;
    public int score = 0;


    // Use this for initialization
    void Start()
    {
        speed = speedArray[0];
        state = 0;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            if (state == 0)
            {
                state = 1;
                dir = Vector3.forward;
                dirFuture = Vector3.left;
            }

            if (dirFuture == Vector3.forward)
            {
                dirFuture = Vector3.left;
                transform.GetChild(3).transform.Rotate(0, -90, 0);
            }
            else
            {
                dirFuture = Vector3.forward;
                transform.GetChild(3).transform.Rotate(0, 90, 0);
            }
        }
    }

    void FixedUpdate()
    {
        if (state == 1)
        {
            state = 2;
            if (!isDead)
            {
                if (dir != dirFuture)
                {
                    if (dirFuture == Vector3.left)
                    {
                        transform.GetChild(2).transform.Rotate(0, -90, 0);
                    } else
                    {
                        transform.GetChild(2).transform.Rotate(0, 90, 0);
                    }
                }
                dir = dirFuture; 
            }

            StartCoroutine("Move");
        }
    }

    IEnumerator Move()
    {
        for (int k = 0; k < 1000; k+=speed)
        {
            float amoutToMove = speed * 0.001f;
            transform.Translate(dir * amoutToMove);
            yield return null;
        }
        state = 1;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile" && !isDead)
        {
            score++;
            if (score % 10 == 0)
            {
                if (score / 10 < 6) speed = speedArray[score / 10];
            }
            scoreText.text = score.ToString();

            RaycastHit hit;
            Ray downRay = new Ray(transform.position, -Vector3.up);

            if(!Physics.Raycast(downRay, out hit) && !isDead)
            {
                isDead = true;
                transform.GetChild(1).transform.parent = null; //sea
                transform.GetChild(0).transform.parent = null; //camera
                resetBtn.SetActive(true);
            }
        }
    }

}
