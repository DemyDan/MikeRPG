using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void ExitApp()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
