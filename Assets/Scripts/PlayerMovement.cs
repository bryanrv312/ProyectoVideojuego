using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform teleportTarget;
    public GameObject player;
    public Rigidbody2D playerRb;
    public float speed = .5f;
    public float jumpspeed = 50;

    public bool enPiso = true;//lo hago publico para utilizarlo en el script playerhealth

    public Animator PlayerAnimator;


    void Start()
    {



    }


    void Update()
    {

        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRb.velocity.y);


        //chequeamos a q lado caminamos
        if (Input.GetAxis("Horizontal") == 0)
        {
            PlayerAnimator.SetBool("isWalking", false);

        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            PlayerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            PlayerAnimator.SetBool("isWalking", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
        if (Input.GetKeyDown(KeyCode.F10))
        {
            player.transform.position = teleportTarget.transform.position;
        }


        if (enPiso)
        {//si esta en el piso
            if (Input.GetKeyDown(KeyCode.Space))
            {//puede saltar

                GetComponent<AudioSource>().Play();
                playerRb.AddForce(Vector2.up * jumpspeed);
                enPiso = false;
                PlayerAnimator.SetTrigger("Jump");
            }
        }


    }



    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Piso") || collision.gameObject.CompareTag("Picos"))
        {//para el bug de salto
            enPiso = true;
        }
    }
}
