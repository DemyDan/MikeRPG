using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public Transform target;

    public float distance = 10.0f;
    public float sensitivity = 3.0f;

    private Vector3 offset;

    void Start()
    {
        //Pakt de afstand tussen de camera positie en target positie. Zorgt ervoor dat deze in stukjes gehakt word en dat kan dat 
        //keer het aantal keer gedaan word wat jij wilt
        offset = (transform.position - target.position).normalized * distance;

        //Initalizes Position to target position + the offset
        transform.position = target.position + offset;
    }

    void Update()
    {
        //Maak een quaternion aan die een rotation is om een object, pak deze via horizontale muisbewegingen * sensitivty
        Quaternion turnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensitivity, Vector3.up);

        //Pas deze quaternion toe op de offset
        offset = turnAngle * offset;

        //Update de rotatie van de camera door het keer de muisinput quaternion te doen
        transform.rotation = turnAngle * transform.rotation;

        //Updates the camera position to target position + the offset
        transform.position = target.position + offset;
    }
}
