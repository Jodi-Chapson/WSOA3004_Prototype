using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    //this script is so that the audio does not get destroyed and can play throughout the game.
    // however, there was an issue as multiple audio gameobjects could be created and played at once - if you return to the menu
    // a solution to this issue was provided by https://www.youtube.com/watch?v=PHa5SNe1Mmk&t

    public static Audio song1;
    
   

    

    public void Start()
    {
        
    }


    private void Awake()
    {



        if (song1 != null)
        {
            //if there is indeed a version of song1 in the scene
            Destroy(gameObject);

        }
        else
        {
            //there is no other instance
            song1 = this;
            DontDestroyOnLoad(transform.gameObject);




        }


    }

    
}
