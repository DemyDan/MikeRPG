using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandWeapon : MonoBehaviour {
    public Rigidbody bullet;
    public GameObject weaponPlace;
    public int arrowSpeed;
    public float secondsBetweenShots;

    private float timestamp;
    private Vector3 shootPoint;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        PickUpText();
    }

    void Shoot()
    {
        //Pakt de rechter kant van de vector
        Vector3 newRight = Vector3.Cross(Vector3.up, transform.forward);

        //Pakt de voorkant van de vector
        Vector3 newForward = Vector3.Cross(newRight, Vector3.up);

        if (Input.GetButtonDown("Fire1") && player.GetComponent<Interact>().playerHasWeapon && player.GetComponent<Interact>().playerHasWand && Time.time >= timestamp)
        {
            shootPoint = weaponPlace.transform.position;

            Rigidbody arrow = Instantiate(bullet, shootPoint, transform.rotation);

            arrow.AddForce(arrowSpeed * -newForward);

            timestamp = Time.time + secondsBetweenShots;
        }
    }

    void PickUpText()
    {
        //Als de wapen opgepakt is dan ItemPickUp uitzetten
        if (player.GetComponent<Interact>().playerHasWeapon)
        {
            GetComponent<ItemPickUp>().enabled = false;
        }
        else if (!player.GetComponent<Interact>().playerHasWeapon)
        {
            GetComponent<ItemPickUp>().enabled = true;
        }
    }
}
