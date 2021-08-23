using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform ghost;
    public GameObject currentVessel;
    public Cam2DFollow cam;
    public Transform spawntwo, spawnthree, spawnfour;
    public int level = 1;

    public void Start()
    {
        cam.target = ghost;
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
            this.GetComponent<SceneChanger>().Scenechanger(1);
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

    public void Teleport(int levelint)
    {
        if (levelint == 1)
        {
            ghost.transform.position = spawntwo.position;
            cam.transform.position = spawntwo.position;
            level++;
        }
        else if (levelint == 2)
        {
            ghost.transform.position = spawnthree.position;
            cam.transform.position = spawnthree.position;
            level++;
        }
        else if (levelint == 3)
        {
            ghost.transform.position = spawnfour.position;
            cam.transform.position = spawnfour.position;
            level++;
        }
        else if (levelint == 4)
        {
            //end
        }


    }

}
