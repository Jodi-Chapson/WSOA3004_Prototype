using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ghost;
    public GameObject currentVessel;
    public CamController cam;

    public void Start()
    {
        cam.target = ghost;
    }
    public void Update()
    {
        

        if (Input.GetKeyDown("e"))
        {
            currentVessel.GetComponent<PlayerController>().isCurrentVessel = false;
            currentVessel = null;
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
            Destroy(currentVessel.gameObject);
            currentVessel = null;
        }


            //turns off ghost movement, and turns off sprite
            ghost.GetComponent<PlayerController>().isActive = false;
            ghost.GetComponent<PlayerController>().isPossessing = true;
            ghost.GetComponent<PlayerController>().sprite.SetActive(false);




            //switches on the host
            currentVessel = host;
            cam.target = host;
            host.GetComponent<PlayerController>().isCurrentVessel = true;
            host.GetComponent<PlayerController>().isActive = true;
            host.GetComponentInChildren<Animator>().SetBool("isPossessed", true);

        


    }

    public void Depossess()
    {
        cam.target = ghost;
        ghost.transform.position = currentVessel.transform.position;
        ghost.GetComponent<PlayerController>().isActive = true;
        ghost.GetComponent<PlayerController>().isPossessing = false;
        ghost.GetComponent<PlayerController>().sprite.SetActive(true);
        



        currentVessel.GetComponent<PlayerController>().isCurrentVessel = false;
        Destroy(currentVessel.gameObject);
        currentVessel = null;
    }

}
