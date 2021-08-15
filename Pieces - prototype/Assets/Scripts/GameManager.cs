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
        //toggles the ghosts features




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
