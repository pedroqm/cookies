using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private PlayerController player;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);
            player.transform.parent = other.transform;
            player.isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.isGrounded = true;
        }
        if (other.gameObject.tag == "Platform")
        {
            player.transform.parent = other.transform;
            player.isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.isGrounded = false;
        }
        if (other.gameObject.tag == "Platform")
        {
            player.transform.parent = null;
            player.isGrounded = false;
        }
    }
}
