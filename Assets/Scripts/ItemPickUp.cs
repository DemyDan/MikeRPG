using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private GameObject player;
    public bool playerIsNearby;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    [TextArea]
    public string text = "";

    private void OnGUI()
    {
        if (playerIsNearby)
        {
            GUI.Box(new Rect(140, Screen.height - 100, Screen.width - 300, 50), ("Press e to pickup " + this.name + "\n" + text));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerIsNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            playerIsNearby = false;
        }
    }
}