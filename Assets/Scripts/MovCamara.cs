using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Transform personaje;


    void Update()
    {

        transform.position = new Vector3(personaje.position.x, transform.position.y, transform.position.z);

    }
}
