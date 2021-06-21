using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    //Reference to the Firesmanager script
    public FiresManager firesManager;
    
    //Variables for the UI
    private int health = 3;
    public Text healthTxt;
    public Text timerTxt;

    // Update is called once per frame
    void Update()
    {
        //Calculates the timesLeft format for use in the UI
        float timer = firesManager.timeLeft;
        timer += Time.deltaTime;
         var minutes = Mathf.FloorToInt(timer / 60); //Divide the guiTime by sixty to get the minutes.
         var seconds = Mathf.FloorToInt(timer % 60);//Use the euclidean division for the seconds.

        //Sets the timeLeft to the right format
        timerTxt.text = "Fire Time: " + string.Format("{0:00} : {1:00}", minutes, seconds);

        //When health is 0 displays "Game Over" text
        if (health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    //Lowers the health and lowers the health on the UI
    public void LowerHealth()
    {
        health--;
        healthTxt.text = "Health: " + health.ToString();
    }
}
