using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float forceJump;
    public float ralentizado;
    private float moverHorizontal;
    private float moverVertical;

    private Rigidbody2D rigPlayer;

    public GameObject flip;

    private float vel;
    private bool travesura;

    [Header("Canvas")]
    public GameObject panelButtonTravesura;
    public GameObject panelGameOver;
    public GameObject panelWin;
    public GameObject panelTime;
    public Text textTime;
    public Text puntuacion;

    [Header("GroundController")]
    //Variables que necesitamos para detectar el suelo
    public bool isGrounded = false;
    public Transform GroundCheck1; // GameObject en los pies
                                   //del personaje
    public LayerMask groundLayer; // Capa suelo
                                  //Variables para detectar suelo

    Animator anim;

    private bool comerGalleta;
    private bool die;

    private void Awake()
    {
        rigPlayer = GetComponent<Rigidbody2D>();
        vel = speed;
        anim = GetComponent<Animator>();
        Time.timeScale = 1;

        comerGalleta = false;
        die = false;
    }


    // Cuando se tocan fisicas se usa el fixed updete
    void FixedUpdate()
    {

        //-----------------------SALTAR---------------------
        if (CrossPlatformInputManager.GetButtonDown("Jump") && (isGrounded))
        {
            rigPlayer.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
            isGrounded = false;
        }

        this.gameObject.transform.Translate(Vector2.right * speed * moverHorizontal * Time.deltaTime);

        //---------------------ANIMACIONES-----------------------------
        Animaciones();
    }

    private void Update()
    {

        moverHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        moverVertical = CrossPlatformInputManager.GetAxis("Vertical");


        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer);

        Flip();



    }
    void Animaciones()
    {
        anim.SetFloat("velocityX", Mathf.Abs(moverHorizontal));
        anim.SetFloat("velocityY", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("ground", isGrounded);
    }


    void Flip()
    {
        if (moverHorizontal < 0)
        {
            flip.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (moverHorizontal > 0)
        {
            flip.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    void GameOver()
    {
         Destroy(this);
         panelGameOver.SetActive(true);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("dead"))
        {
            anim.Play("Morir");
            Invoke("GameOver",1);
        }
        if (collision.CompareTag("LimiteIzq"))
        {
            Debug.Log(travesura);
            // Si travesura esta activado y llega al limite izquierdo el jugador gana
            if (travesura)
            {
                Debug.Log("Entra 1");
                panelWin.SetActive(true);
                puntuacion.text = "Total time: " + textTime.text;
                panelTime.SetActive(false);
                Time.timeScale = 0;
            }

            if (moverHorizontal < 0)
            {
                speed = 0;
            }
            if (moverHorizontal > 0)
            {
                speed = vel;
            }

        }

        if (collision.CompareTag("LimiteDe"))
        {

            if (moverHorizontal > 0)
            {
                Debug.Log("Entra 2");

                speed = 0;
            }
            if (moverHorizontal < 0)
            {
                speed = vel;
            }

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Paint"))
        {
            Debug.Log("Sale paint");
            speed = vel;
        }

        if (collision.CompareTag("LimiteDe"))
        {
            panelButtonTravesura.SetActive(false);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Paint"))
        {
            speed = ralentizado;
        }
        if (collision.CompareTag("LimiteIzq"))
        { 
            if (moverHorizontal < 0)
            {
                speed = 0;
            }
            if (moverHorizontal > 0)
            {
                speed = vel;
            }
        }
        if (collision.CompareTag("LimiteDe"))
        {
            if (travesura)
            {
                if (!comerGalleta)
                {
                    Debug.Log("Travesura realizada 2: " + travesura);

                    anim.Play("ComerseGalleta");
                    anim.SetBool("comerGalleta", true);                   
                    panelButtonTravesura.SetActive(false);
                    comerGalleta = true;
                }
            }
            else
            {
                Debug.Log("Travesura realizada 1: " + travesura);
                panelButtonTravesura.SetActive(true);
            }
            if (moverHorizontal > 0)
            {
                speed = 0;
            }
            if (moverHorizontal < 0)
            {
                speed = vel;
            }
        }
    }

    public void Travesura()
    {
        travesura = true;
    }
}
