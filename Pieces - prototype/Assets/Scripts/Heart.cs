using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameManager manager;
    public GameObject memorytext, endscreen;
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
        if (manager.currentVessel != null)
        {
            //means the player is current possessing something.
            manager.Depossess();

            
           

        }

        manager.GetComponent<SceneChanger>().Scenechanger(nextlevel);


        //manager.Teleport(manager.level);
    }
}
