using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    [Header("References")]
    public GameManager manager;

    public void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player");
            if (manager.currentVessel != null)
            {
                manager.Depossess();
            }
        }
    }




}
