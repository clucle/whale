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
        speed = 50;
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
    }

    void FixedUpdate()
    {
        if (state == 1)
        {
            state = 2;
            dir = dir_future;
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
}

//Vector3 currnetVector = transform.position;
//Vector3 tmpVector;
/*
if (dir == Vector3.forward)
{
    tmpVector = new Vector3(0, 0, 0.1f) + currnetVector;
    currnetVector = tmpVector;
    transform.position = tmpVector;
} else
{
    tmpVector = new Vector3(-0.1f, 0, 0) + currnetVector;
    currnetVector = tmpVector;
    transform.position = tmpVector;
}*/

