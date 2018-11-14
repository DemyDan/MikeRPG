﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    Enemy enemy;

    public int damage;
    public float secondsBetweenShots;

    private float timestamp;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
	}

    // Update is called once per frame
    void Update() {
        //Als de wapen opgepakt is dan ItemPickUp uitzetten
        if(player.GetComponent<Interact>().playerHasWeapon)
        {
            GetComponent<ItemPickUp>().enabled = false;
        }   

        if (Input.GetButtonDown("Fire1") && player.GetComponent<Interact>().playerHasWeapon && player.GetComponent<Interact>().playerHasSword && Time.time >= timestamp)
        {
            RaycastHit hit;

            int layermask = LayerMask.GetMask("Enemy");

            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 1f, layermask))
            {
                enemy = hit.collider.GetComponent<Enemy>();
                enemy.Damage(damage);
                Debug.Log("Hit");
            }

            timestamp = Time.time + secondsBetweenShots;

            Debug.DrawRay(player.transform.position, player.transform.forward * hit.distance, Color.yellow);
        }
    }
}
