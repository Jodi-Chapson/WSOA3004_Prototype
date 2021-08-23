using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameManager manager;
    public GameObject memorytext;
    public int nextlevel;

    public void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Player")
        //{

        //    this.GetComponentInChildren<SpriteRenderer>().enabled = false;
        //    memorytext.SetActive(true);
        //    StartCoroutine(End());

        //}
    }

    


    public void OnMouseDown()
    {


        

        manager.Memory(memorytext, 0);


        
    }
}
