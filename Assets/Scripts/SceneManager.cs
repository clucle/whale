using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeToScene()
    {
        AutoFade.LoadLevel("whale", 0.5f, 0.5f, Color.black);
        //Application.LoadLevel("game");
    }
}
