using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

    public float force;

    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward,out hit,0.5f))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                CharacterController cc = hit.collider.gameObject.GetComponent<CharacterController>();
                cc.Move(transform.forward * force);
                Destroy(gameObject);
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
