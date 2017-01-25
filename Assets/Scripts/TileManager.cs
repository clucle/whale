using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    public GameObject currentTile;

    private static TileManager instance;

    public static TileManager Instance
    {
        get {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }
    }

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 20; i++)
        {
            SpawnTile();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnTile()
    {
        int randomIndex = Random.Range(0, 2);

        currentTile = (GameObject)Instantiate(tilePrefabs[randomIndex], 
             currentTile.transform.GetChild(0)
            .transform.GetChild(randomIndex).position, Quaternion.identity);
    }
}

