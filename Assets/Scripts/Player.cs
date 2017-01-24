using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int speed;

    private byte state; // 0 stop, 1 select, 2 move

    private Vector3 dir;
    private Vector3 dir_future;

    private bool isDead;

    // Use this for initialization
    void Start()
    {
        speed = 50;
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
                dir_future = Vector3.left;
            }

            if (dir_future == Vector3.forward)
            {
                dir_future = Vector3.left;
            }
            else
            {
                dir_future = Vector3.forward;
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
                dir = dir_future; 
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
            RaycastHit hit;
            Ray downRay = new Ray(transform.position, -Vector3.up);

            if(!Physics.Raycast(downRay, out hit) && !isDead)
            {
                isDead = true;
                transform.GetChild(0).transform.parent = null;
            }
        }
    }
}
