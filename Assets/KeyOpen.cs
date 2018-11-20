using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOpen : MonoBehaviour {

    private GameObject player;
    string trollKey = "TrollKey";
    string bossKey = "BossKey";

    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.name == trollKey && other.CompareTag("DoorTroll"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (gameObject.name == bossKey && other.CompareTag("DoorBoss"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    [TextArea]
    public string text = "";

    private void OnGUI()
    {
        if (player.GetComponent<Interact>().playerSeesItem)
        {
            GUI.Box(new Rect(140, Screen.height - 100, Screen.width - 300, 50), ("Press e to pickup " + this.name + "\n" + text));
        }
    }
}
