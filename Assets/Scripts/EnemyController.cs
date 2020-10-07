using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;
    private float vel;
    public static bool travesura;
    public Transform[] danger;
    public GameObject zapatilla;
    private Animator anim;
    public float frecuenciaDisparo;
    private bool atacando;
    private float timer;
    public bool andar1vez;

    GameController gameController;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        vel = 0;
        travesura = false;
        anim = GetComponent<Animator>();
        atacando = false;
        timer = 0;
        andar1vez = true;
    }

    private void FixedUpdate()
    {
        rig.velocity = transform.right * vel;
    }


    private void Update()
    {
        if (travesura)
        {
            if (andar1vez)
            {
                Andar();
                andar1vez = false;
            }

            if (timer > frecuenciaDisparo)
            {
                Debug.Log("dispara");
                atacando = true;
                Invoke("Disparar", 0.2f);
                timer = 0;
            }

            timer += Time.deltaTime;
           
        }
    }

    void Disparar()
    {
        atacando = false;
        anim.Play("disparar");
        vel = 0;
        int posZapatilla =  Random.Range(0,2);

        Transform lanzarZapatilla = danger[Random.Range(0, danger.Length)];

        Instantiate(zapatilla, lanzarZapatilla.transform.position, transform.rotation);
        if (!atacando)
        {
            Invoke("Andar", 0.5f);
        }

    }

    void Andar() 
    {
        vel = speed;
        anim.Play("andar");       
    }

    public void Travesura()
    {
        travesura = true;
    }
}
