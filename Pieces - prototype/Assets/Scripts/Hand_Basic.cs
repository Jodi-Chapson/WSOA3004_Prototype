using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Basic : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("end");
        }
    }
}
