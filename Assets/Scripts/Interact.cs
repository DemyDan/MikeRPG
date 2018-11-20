using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public Camera cam;
    public GameObject keyPlace;

    public bool playerSeesItem = false;
    public bool playerIsWithItem = false;
    public bool playerHasWeapon = false;
    public bool playerHasBow = false;
    public bool playerHasSword = false;
    public bool playerHasWand = false;
    public bool pressedE = false;
    public Transform weaponPlace;
    public Transform weaponDrop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DropWeapon();
        CheckItem();
	}

    void CheckItem()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if(hit.collider.CompareTag("Item"))
            {
                playerSeesItem = true;
                if(Input.GetKeyDown("e"))
                {
                    Debug.Log("Got Object");
                    hit.collider.gameObject.transform.position = keyPlace.transform.position;
                    hit.collider.gameObject.transform.parent = keyPlace.transform;
                }
            }
            Debug.DrawRay(transform.position, transform.forward * 2f, Color.yellow);
        }
        else
        {
            playerSeesItem = false;
        }
    }

    void DropWeapon()
    {
        if (Input.GetKeyDown("q") && playerHasWeapon)
        {
            weaponPlace.GetChild(0).transform.position = weaponDrop.transform.position;
            weaponPlace.DetachChildren();

            playerHasWeapon = false;
            playerHasBow = false;
            playerHasSword = false;
            playerHasWand = false;
        }
    }

    void OnTriggerStay (Collider other)
    {
        if(other.CompareTag("Bow") || other.CompareTag("Sword") || other.CompareTag("Wand"))
        {
            playerIsWithItem = true;
        }

        if(playerIsWithItem && !playerHasWeapon)
        {
            if(Input.GetKeyDown("e"))
            {
                if (other.CompareTag("Bow"))
                {
                    playerHasBow = true;
                }
                else if (other.CompareTag("Sword"))
                {
                    playerHasSword = true;
                }
                else if (other.CompareTag("Wand"))
                {
                    playerHasWand = true;
                }
                    playerHasWeapon = true;
                other.gameObject.transform.position = weaponPlace.transform.position;
                other.gameObject.transform.rotation = weaponPlace.rotation;
                other.gameObject.transform.parent = weaponPlace.transform;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bow") || other.CompareTag("Sword") || other.CompareTag("Wand"))
        {
            playerIsWithItem = false;
        }
    }
}
