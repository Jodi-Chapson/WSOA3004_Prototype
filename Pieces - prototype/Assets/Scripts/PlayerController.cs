using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;
    

    [Header("Variables")]
    public Vector2 movement;
    public float movespeed;
    public bool isHiding; //is true, if the player is current haunting an object
    public bool canHaunt; //is true, if the player is near a hauntable object

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        isHiding = false;
        canHaunt = false;
    }

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        //press this when near an object to haunt it, will configure more bools later to influence this ability.
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("hiding");
            if(canHaunt && !isHiding)
            {
                //let the player haunt
                
                isHiding = true;
            }
        }
        
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.deltaTime);
    }
}
