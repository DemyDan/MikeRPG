using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDied : MonoBehaviour {

    public GameObject target;
    public bool activate;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnDestroy()
    {
        target.SetActive(activate);
    }
}
