using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform player;       // Reference to the player's transform.


    void Awake()
    {
        // Setting up the reference.
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void FixedUpdate()
    {
        transform.position = player.position + new Vector3(5f, 5f, -5f);
    }
}
