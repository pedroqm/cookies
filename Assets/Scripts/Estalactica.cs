using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estalactica : MonoBehaviour
{
    public float fallDelay = 1f;

    private Rigidbody2D rb2d;

    public GameObject dead;
    public bool destruir;
    public bool isGrounded = false;

    private AudioSource efectoRomper;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        efectoRomper = GetComponent<AudioSource>();

    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("cae lampara");
            Invoke("Caer", fallDelay);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!rb2d.isKinematic)
        {
            efectoRomper.Play();
            dead.SetActive(false);
        }

        destruir = false;
        isGrounded = true;
        //Invoke("Destruir", 0.4f);
        rb2d.isKinematic = true;

    }
    void Destruir()
    {
        Destroy(this.gameObject);
    }
    void Caer()
    {
       
        if (!isGrounded)
        {
            rb2d.isKinematic = false; //para que al tocar el collider, caiga.
            dead.SetActive(true);
        }
    }
}
