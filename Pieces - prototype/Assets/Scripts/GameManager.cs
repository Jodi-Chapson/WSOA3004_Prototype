using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("References")]
    public Transform ghost;
    public GameObject currentVessel;
    public GameObject currentdialogue;
    public Cam2DFollow cam;
    public int currentlevel;
    public bool dialogueopen;
    public bool isMemory;
    public bool isEnd;
    public int mouseclick = 0;
    public GameObject endscreen;
    

    public void Start()
    {
        cam.target = ghost;
        currentVessel = null;
        dialogueopen = false;
    }


    public void Dialogue(GameObject targetdialogue, int type)
    {
        currentdialogue = targetdialogue.gameObject;
        

        if (currentVessel != null)
        {
            currentVessel.GetComponent<PlayerController>().isActive = false;
            currentVessel.GetComponent<PlayerController>().isFrozen = true;

            

        }
        else
        {
            
            //in ghost form
            ghost.GetComponent<PlayerController>().isActive = false;
            ghost.GetComponent<PlayerController>().isFrozen = true;
            

        }

        mouseclick = type;

        currentdialogue.SetActive(true);
        dialogueopen = true;


    }

    public void Memory(GameObject targetdialogue, int type)
    {

        currentdialogue = targetdialogue.gameObject;


        if (currentVessel != null)
        {
            Depossess();
        }

            
            ghost.GetComponent<PlayerController>().isActive = false;
            ghost.GetComponent<PlayerController>().isFrozen = true;



        mouseclick = type;
        currentdialogue.SetActive(true);
        dialogueopen = true;
        isMemory = true;



    }

    

    public void Update()
    {
        

        if (Input.GetKeyDown ("escape"))
        {
            Debug.Log("close game");
            this.GetComponent<SceneChanger>().Exit();
        }

        if (Input.GetKeyDown("r"))
        {
            this.GetComponent<SceneChanger>().Scenechanger(currentlevel);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueopen)
            {
                mouseclick++;

                if (mouseclick == 2)
                {
                    //so there is a dialogue open
                    currentdialogue.SetActive(false);
                    currentdialogue = null;

                    if (currentVessel != null)
                    {
                        currentVessel.GetComponent<PlayerController>().isActive = true;
                        currentVessel.GetComponent<PlayerController>().isFrozen = false;
                    }
                    else
                    {

                        ghost.GetComponent<PlayerController>().isActive = true;
                        ghost.GetComponent<PlayerController>().isFrozen = false;
                    }

                    dialogueopen = false;
                    mouseclick = 0;

                    if (isMemory)
                    {
                        this.GetComponent<SceneChanger>().Scenechanger(currentlevel + 1);
                    }

                    if (isEnd)
                    {
                        endscreen.SetActive(true);
                    }
                }
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            if (currentVessel != null)
            {
                Depossess();
            }
        }
    }

    public void Possess(GameObject host)
    {
        if (currentVessel != null)
        {
            currentVessel.GetComponent<PlayerController>().Depossessed();
            //Destroy(currentVessel.gameObject);
            currentVessel = null;

            
        }


            //turns off ghost movement, and turns off sprite
            ghost.GetComponent<PlayerController>().isActive = false;
            ghost.GetComponent<PlayerController>().isPossessing = true;
        ghost.GetComponent<PlayerController>().GetComponentInChildren<SpriteRenderer>().enabled = true;
        ghost.GetComponentInChildren<Animator>().SetBool("isBall", true);
        ghost.GetComponent<Rigidbody2D>().gravityScale = 0;
        ghost.GetComponent<CapsuleCollider2D>().enabled = false;
        ghost.GetComponentInChildren<ParticleSystem>().Stop();
        ghost.GetComponent<PlayerController>().isTransfering = true;




            //switches on the host
            currentVessel = host;
            cam.target = host.transform;
            host.GetComponent<PlayerController>().isCurrentVessel = true;
            
            

        


    }

    public void CompletePossess()
    {
        ghost.GetComponent<PlayerController>().GetComponentInChildren<SpriteRenderer>().enabled =false;
        currentVessel.GetComponent<PlayerController>().isActive = true;
        currentVessel.GetComponentInChildren<Animator>().SetBool("isPossessed", true);
        currentVessel.GetComponent<PlayerController>().orbs.Play();

    }

    public void Depossess()
    {
        cam.target = ghost;
        ghost.transform.position = currentVessel.transform.position;
        ghost.GetComponent<PlayerController>().isActive = true;
        ghost.GetComponent<PlayerController>().isPossessing = false;
        ghost.GetComponent<PlayerController>().GetComponentInChildren<SpriteRenderer>().enabled = true;

        ghost.GetComponentInChildren<Animator>().SetBool("isBall", false);
        Debug.Log("nani?");

        ghost.GetComponent<Rigidbody2D>().gravityScale = 1;
        ghost.GetComponent<CapsuleCollider2D>().enabled = true;
        ghost.GetComponentInChildren<ParticleSystem>().Play();


        currentVessel.GetComponent<PlayerController>().Depossessed();
        currentVessel = null;




        //currentVessel.GetComponent<PlayerController>().isCurrentVessel = false;
        //Destroy(currentVessel.gameObject);
        
    }

    

}
