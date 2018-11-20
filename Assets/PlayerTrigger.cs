using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour {

    public GameObject target;
    public bool enable;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            target.SetActive(enable);
        }
    }
}
