using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Tim Gijzen
    //Set this on the UI

    //Set UI text in here 
    public Text scoreDisplay;

    //The score
    public float currentScore;

    //Get-set from LevelCountdown Script
    public float remTime;

    //Get-set from EnemyAI Script
    public int enemyDead = 0;

    //Set LevelCountdown and EnemyAI on this gameobject to let this script work
    public GameObject scriptManagerCountdown;

    public int secondsScore;

    void Update()
    {
        //Get values from other scripts script = <>
           remTime = scriptManagerCountdown.GetComponent<LevelCountdown>().remainingtime;
        
        //RemTime for every second left +10 score
        //EnemyDead for every Enemy dead +35 score
        currentScore = secondsScore * 1 + enemyDead * 35;


        secondsScore = Mathf.FloorToInt(remTime % 300f);

        //set score to : Score: CurrentScore
        scoreDisplay.text = ("Score: ")+ currentScore.ToString();
    }
}
