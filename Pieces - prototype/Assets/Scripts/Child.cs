using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    [Header("References")]
    public GameManager manager;
    public GameObject outline;
    public GameObject dialogue;



    [Header("States")]
    public bool canClick;



    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseOver()
    {

        if (canClick)
        {
            float distance = Vector2.Distance(manager.GetComponent<GameManager>().ghost.transform.position, this.transform.position);
            if (distance < 5)
            {



                outline.SetActive(true);

            }
        }

    }

    public void OnMouseExit()
    {




        outline.SetActive(false);


    }

    public void OnMouseDown()
    {

        {
            float distance = Vector2.Distance(manager.GetComponent<GameManager>().ghost.transform.position, this.transform.position);
            if (distance < 5)
            {
                //dialogue
                
                outline.SetActive(false);
                canClick = false;

                manager.Dialogue(dialogue, 0);
                manager.isEnd = true;
                



            }

        }


    }
}
