using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{

    Camera m_Camera;

    void Start()
    {
        m_Camera = Camera.main;
    }

    //Draai met de camera mee
    void Update()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                         m_Camera.transform.rotation * Vector3.up);
    }
}