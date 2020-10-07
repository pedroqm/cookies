using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    private Rigidbody2D rig;
    public float speed;

    // Use this for initialization
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        rig.velocity = transform.right * speed;
    }

}
