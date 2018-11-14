using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    CharacterController cc;

    public Transform cam;

    public float gravity;
    public float speed;
    public float playerStill;

    Vector3 movement;

    void Start()
    {
        Cursor.visible = false;

        playerStill = this.transform.rotation.y;

        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Cursor.visible = false;
        Move();
    }

    void Move()
    {
        //Pakt de 2 vectoren die nodig zijn voor horizontaal en verticaal lopen en stopt ze in een vector 2
        Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Zorgt ervoor dat de movement niet laggy is, hoeft ie nog niet helemaal te weten
        if (inputDirection.sqrMagnitude > 1)
        {
            inputDirection = inputDirection.normalized;
        }

        /**
         * 
         *      public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.y * rhs.z - lhs.z * rhs.y,
                lhs.z * rhs.x - lhs.x * rhs.z,
                lhs.x * rhs.y - lhs.y * rhs.x);
        }
        **/
        //Pakt de rechter kant van de vector
        Vector3 newRight = Vector3.Cross(Vector3.up, cam.forward);

        //Pakt de voorkant van de vector
        Vector3 newForward = Vector3.Cross(newRight, Vector3.up);

        //Pak de uitkomensten van de vectoren en doe ze keer je input, plus teken is voor als je beide kanten op wilt, doe dan de vectoren plus elkaar
        Vector3 movement = (newRight * inputDirection.x) + (newForward * inputDirection.y);

        //Zorgt ervoor dat je poppetje niet zweeft
        movement.y -= (gravity * Time.deltaTime);

        //Move je CC keer de speed die jij wilt
        cc.Move(movement * speed);

        //Pak de rotatie van de player en maak die op de y as hetzelfde als die van de camera
        transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
    }
}
