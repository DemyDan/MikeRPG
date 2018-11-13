using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    CharacterController cc;

    void Start()
    {
        Cursor.visible = false;

        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        move();
    }

    void move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");


    }
}
