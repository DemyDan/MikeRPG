using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour {

    public Rigidbody ammo;
    public Transform shootPoint;
    public float speed;
    public float secondsBetweenShots;

    private float timestamp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= timestamp)
        {
            Rigidbody ball = Instantiate(ammo, shootPoint.position, transform.rotation);

            ball.AddForce(transform.forward * speed);

            timestamp = Time.time + secondsBetweenShots;
        }
	}
}
