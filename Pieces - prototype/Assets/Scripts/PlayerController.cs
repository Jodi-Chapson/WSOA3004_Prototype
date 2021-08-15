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
    public Vector2 movement;
    public float movespeed;
    
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


    void Update()
    {
        if (isActive)
        {
            movement.x = Input.GetAxisRaw("Horizontal");

            

        }
        else if (isPossessing)
        {
            this.transform.position = manager.currentVessel.transform.position;
        }


        

        







    }

    public void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * movespeed, rb.velocity.y);

        Flip();
    }


    public void Flip()
    {
        if (movement.x < 0)
        {
            if (sprite.transform.localScale.x != xScale)
            {
                sprite.transform.localScale = new Vector3(xScale, sprite.transform.localScale.y, sprite.transform.localScale.z);
            }
        }
        else if (movement.x > 0)
        {
            if (sprite.transform.localScale.x != -xScale)
            {
                sprite.transform.localScale = new Vector3(-xScale, sprite.transform.localScale.y, sprite.transform.localScale.z);
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
