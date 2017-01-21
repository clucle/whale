using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int speed;

    private byte state; // 0 stop, 1 select, 2 move

    private Vector3 dir;
    private Vector3 dir_future;

    // Use this for initialization
    void Start()
    {
        speed = 1;
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        if (state == 1)
        {
            state = 2;
            dir = dir_future;
            StartCoroutine("Move");
        }
    }

    IEnumerator Move()
    {
        for (int k = 0; k < 60; k+=speed)
        {
            float amoutToMove = speed * Time.deltaTime;
            transform.Translate(dir * amoutToMove);
            yield return null;
        }
        state = 1;
    }
}