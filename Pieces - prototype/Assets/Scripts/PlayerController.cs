using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum CreatureType { GHOST, RAT, CROW }

    [Header("References")]
    public Rigidbody2D rb;
    public GameObject sprite;
    public GameManager manager;

    [Header("Player Configurations")]
    public bool isVessel;
    public CreatureType type;

    [Header("States")]
    
    public bool isCurrentVessel;
    public bool isActive;
    public bool isPossessing;
    public bool isGrounded;

    [Header("Variables")]
    
    public float movespeed;
    public float jump;
    
    public float xScale;
    



    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        rb = this.GetComponent<Rigidbody2D>();

        xScale = sprite.transform.localScale.x;
        


        if (isVessel)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }
    }


    public void Update()
    {
        if (isActive)
        {
            if (isGrounded && type == CreatureType.RAT)
            {

                if (Input.GetKeyDown("w"))
                {


                    rb.velocity = new Vector2(rb.velocity.x, jump);






                }
            }
            else if (type == CreatureType.CROW)
            {
                if (Input.GetKey("w"))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jump);
                    
                }
                else if (Input.GetKey("s"))
                {
                    rb.velocity = new Vector2(rb.velocity.x, -jump);
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                }
            }
        }
    }


    public void FixedUpdate()
    {

        if (isActive)
        {
            if (Input.GetKey("a"))
            {
                rb.velocity = new Vector2(-movespeed, rb.velocity.y);
                Flip();
            }
            else if (Input.GetKey("d"))
            {
                rb.velocity = new Vector2(movespeed, rb.velocity.y);
                Flip();

            }
            else
            {


                rb.velocity = new Vector2(0, rb.velocity.y);



            }



        }
        else if (isPossessing)
        {
            this.transform.position = manager.currentVessel.transform.position;
        }
        
    }



    public void Flip()
    {
        if (rb.velocity.x < 0)
        {
            if (type != CreatureType.CROW)
            {




                if (sprite.transform.localScale.x != xScale)
                {
                    sprite.transform.localScale = new Vector3(xScale, sprite.transform.localScale.y, sprite.transform.localScale.z);
                }
            }
            else
            {
                if (sprite.transform.localScale.x != -xScale)
                {
                    sprite.transform.localScale = new Vector3(-xScale, sprite.transform.localScale.y, sprite.transform.localScale.z);
                }
            }
        }
        else if (rb.velocity.x > 0)
        {
            if (type != CreatureType.CROW)
            {


                if (sprite.transform.localScale.x != -xScale)
                {
                    sprite.transform.localScale = new Vector3(-xScale, sprite.transform.localScale.y, sprite.transform.localScale.z);
                }
            }
            else
            {
                if (sprite.transform.localScale.x != xScale)
                {
                    sprite.transform.localScale = new Vector3(xScale, sprite.transform.localScale.y, sprite.transform.localScale.z);
                }
            }
        }
    }


    public void OnMouseDown()
    {
        if (isVessel && !isCurrentVessel)
        {
            float distance = Vector2.Distance(manager.GetComponent<GameManager>().ghost.transform.position, this.transform.position);
            if (distance < 3)
            {
                manager.Possess(this.gameObject);
            }
            
        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {

        }
    }
}
