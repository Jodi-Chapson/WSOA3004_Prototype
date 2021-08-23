using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject dialogue;
    public GameManager manager;
    public bool canTrigger;

    public void Start()
    {
        canTrigger = true;
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (canTrigger)
            {
                manager.Dialogue(dialogue, 1);
                canTrigger = false;
            }
        }
    }
}
