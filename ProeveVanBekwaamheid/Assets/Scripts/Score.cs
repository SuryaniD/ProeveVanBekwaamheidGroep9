//Tim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    //Set this on the UI

    //Set UI text in here 
    public Text lifeDisplay;

    //The score
    public float currentScore;

    //Get-set from LevelCountdown Script
    public float remTime;

    //Get-set from EnemyAI Script
    public float enemyDead;

    //Set LevelCountdown and EnemyAI on this gameobject to let this script work
    public GameObject scriptManager;

    void Update()
    {
        //Get values from other scripts script = <>
     //   remTime = ScriptManager.GetComponent<levelCountdown>().remainingtime;
      //  enemyDead = ScriptManager.GetComponent<enemyAI>().EnemiesDead;

        //RemTime for every second left +10 score
        //EnemyDead for every Enemy dead +35 score
        currentScore = remTime * 10f + enemyDead * 35f;

        //set score to : Score: CurrentScore
        lifeDisplay.text = ("Score: ")+currentScore.ToString();
    }
}
