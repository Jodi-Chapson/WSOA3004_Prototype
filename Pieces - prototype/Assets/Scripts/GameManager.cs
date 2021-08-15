using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ghost;
    public GameObject currentVessel;


    public void Update()
    {
        

        if (Input.GetKeyDown("e"))
        {
            currentVessel.GetComponent<PlayerController>().isCurrentVessel = false;
            currentVessel = null;
        }
    }

    public void Possess(GameObject host)
    {
        //turns off ghost movement, and turns off sprite
        ghost.GetComponent<PlayerController>().isActive = false;
        ghost.GetComponent<PlayerController>().isPossessing = true;
        ghost.GetComponent<PlayerController>().sprite.SetActive(false);



        //switches on the host
        currentVessel = host;
        host.GetComponent<PlayerController>().isCurrentVessel = true;
        host.GetComponent<PlayerController>().isActive = true;


    }

    public void Depossess()
    {

        currentVessel.GetComponent<PlayerController>().isCurrentVessel = false;
        currentVessel = null;
    }

}
