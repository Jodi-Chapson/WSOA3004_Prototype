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
    public bool isGrounded;
    public bool isCurrentVessel;
    public bool isActive;

    [Header("Variables")]
    public Vector2 movement;
    public float movespeed;
    public float xScale;



    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        rb = this.GetComponent<Rigidbody2D>();

        xScale = sprite.transform.localScale.x;
        isGrounded = false;


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



        if (isGrounded)
        {
            movement.y = 0;
        }
        else
        {
            movement.y = -0.5f;
        }



    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);

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
            Debug.Log("possessed");
            

            manager.Possess(this.gameObject);


        }


    }
}
