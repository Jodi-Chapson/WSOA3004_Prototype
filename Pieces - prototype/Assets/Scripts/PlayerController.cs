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
    public GameObject outline1, outline2, outline3, outline4;

    [Header("Player Configurations")]
    public bool isVessel;
    public CreatureType type;
    public bool hasIdle;
    [Header("States")]
    
    public bool isCurrentVessel;
    public bool isActive;
    public bool isPossessing;
    public bool isTransfering;
    public bool isGrounded;

    [Header("Variables")]
    
    public float movespeed;
    public float jump;
    public float lerp;
    
    public float xScale;
    



    void Start()
    {
        isTransfering = false;
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

                    if (hasIdle)
                    {
                        this.GetComponentInChildren<Animator>().SetBool("isMoving", true);
                    }

                    isGrounded = false;




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


                if (hasIdle)
                {
                    this.GetComponentInChildren<Animator>().SetBool("isMoving", true);
                }

                Flip();

                if (type == CreatureType.GHOST)
                {
                    this.GetComponentInChildren<SpriteRenderer>().gameObject.transform.localRotation = Quaternion.Euler(0, 0, 3);
                }
            }
            else if (Input.GetKey("d"))
            {
                rb.velocity = new Vector2(movespeed, rb.velocity.y);

                if (hasIdle)
                {
                    this.GetComponentInChildren<Animator>().SetBool("isMoving", true);
                }

                Flip();
                if (type == CreatureType.GHOST)
                {
                    this.GetComponentInChildren<SpriteRenderer>().gameObject.transform.localRotation = Quaternion.Euler(0, 0, -9);
                }

            }
            else
            {

                
                rb.velocity = new Vector2(0, rb.velocity.y);
                
                if (isGrounded && hasIdle)
                {
                    this.GetComponentInChildren<Animator>().SetBool("isMoving", false);
                }

                if (type == CreatureType.GHOST)
                {
                   this.GetComponentInChildren<SpriteRenderer>().gameObject.transform.localRotation = Quaternion.Euler(0, 0, -3);
                }

            }


            if (type == CreatureType.RAT)
            {
                if (jump > 8)
                {
                    if (isGrounded)
                    {
                        rb.gravityScale = 2;
                    }
                    else if (!isGrounded && rb.velocity.y < 0)
                    {
                        rb.gravityScale = 4;
                    }
                }
            }
        



    }
        else if (isPossessing)
        {
            //this.transform.position = manager.currentVessel.transform.position;
            Vector3 currentpos;
            
            currentpos.x = Mathf.Lerp(this.transform.position.x, manager.currentVessel.transform.position.x, lerp);
            currentpos.y = Mathf.Lerp(this.transform.position.y, manager.currentVessel.transform.position.y, lerp);
            currentpos.z = 0;
            transform.position = currentpos;

            float distance;

            distance = Vector2.Distance(currentpos, manager.currentVessel.transform.position);
            if (isTransfering)
            {
                if (distance < 0.05f)
                {
                    Debug.Log("huzzah betch");


                    this.GetComponentInChildren<TrailRenderer>().enabled = false;
                    isTransfering = false;
                    manager.CompletePossess();
                    //also do the other half of the possess

                }
                else
                {
                    this.GetComponentInChildren<TrailRenderer>().enabled = true;
                }
            }


        }
        else if (isVessel)
        {
            if (type == CreatureType.RAT)
            {
                if (isGrounded)
                {
                    rb.velocity = Vector2.zero;

                }
            }
            
        }
        
    }



    public void Flip()
    {
        if (rb.velocity.x < 0)
        {
            if (type != CreatureType.CROW && type != CreatureType.RAT)
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
            if (type != CreatureType.CROW && type != CreatureType.RAT)
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

    public void OnMouseOver()
    {
        if (isVessel && !isCurrentVessel)
        {
            float distance = Vector2.Distance(manager.GetComponent<GameManager>().ghost.transform.position, this.transform.position);
            if (distance < 5)
            {

                if (type == CreatureType.CROW)
                {
                    outline1.GetComponent<SpriteRenderer>().enabled = true;
                    outline2.GetComponent<SpriteRenderer>().enabled = true;
                    outline3.GetComponent<SpriteRenderer>().enabled = true;
                    outline4.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    outline1.SetActive(true);
                }
            }
        }
    }

    public void OnMouseExit()
    {
        if (isVessel)
        {
            if (type == CreatureType.CROW)
            {
                outline1.GetComponent<SpriteRenderer>().enabled = false;
                outline2.GetComponent<SpriteRenderer>().enabled = false;
                outline3.GetComponent<SpriteRenderer>().enabled = false;
                outline4.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                outline1.SetActive(false);
            }
        }
    }

    public void OnMouseDown()
    {
        if (isVessel && !isCurrentVessel)
        {
            float distance = Vector2.Distance(manager.GetComponent<GameManager>().ghost.transform.position, this.transform.position);
            if (distance < 5)
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
