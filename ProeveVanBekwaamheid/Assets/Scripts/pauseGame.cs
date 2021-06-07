using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseGame : MonoBehaviour
{
    bool isPaused;
    public Image pauseScreen;

    void Start()
    {
        isPaused = false;   
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            if (!isPaused)
            {
                Pause();
             
            }
            else Unpause();
               
        }
       
    }

    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        var opacity = pauseScreen.color;
        opacity.a = 1f;
        pauseScreen.color = opacity;
    }

    void Unpause()
    {
        Time.timeScale = 1f;
        isPaused = false;
        var opacity = pauseScreen.color;
        opacity.a = 0f;
        pauseScreen.color = opacity;
    }
}
