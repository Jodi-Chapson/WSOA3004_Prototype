using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{
    public PlayerController player;
    
    

    public void Start()
    {
        
        
        
            player = GetComponentInParent<PlayerController>();

        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            
            
            
                player.isGrounded = true;

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            
            
            {
                player.isGrounded = false;

            }
        }
    }
}
