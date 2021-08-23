using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Basic : MonoBehaviour
{
    public SceneChanger scenechange;

    public void Start()
    {
        scenechange = GameObject.Find("Game Manager").GetComponent<SceneChanger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            scenechange.Scenechanger(scenechange.GetComponent<GameManager>().currentlevel);
            
        }
    }
}
