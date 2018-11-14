using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowWeapon : MonoBehaviour {

    public Rigidbody bullet;
    public GameObject weaponPlace;
    public int arrowSpeed;
    public float secondsBetweenShots;

    private float timestamp;
    private Vector3 shootPoint;
    private GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //Als de wapen opgepakt is dan ItemPickUp uitzetten
        if (player.GetComponent<Interact>().playerHasWeapon)
        {
            GetComponent<ItemPickUp>().enabled = false;
        }


        if(Input.GetButtonDown("Fire1") && player.GetComponent<Interact>().playerHasWeapon && player.GetComponent<Interact>().playerHasBow && Time.time >= timestamp)
        {
            shootPoint = weaponPlace.transform.position;

            Rigidbody arrow = Instantiate(bullet, shootPoint, transform.rotation);

            arrow.AddForce(arrowSpeed * -transform.forward);

            timestamp = Time.time + secondsBetweenShots;
        }
    }
}
