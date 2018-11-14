using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public bool playerIsWithItem = false;
    public bool playerHasWeapon = false;
    public bool playerHasBow = false;
    public bool playerHasSword = false;
    public bool playerHasWand = false;
    public bool pressedE = false;
    public Transform weaponPlace;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
           

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
