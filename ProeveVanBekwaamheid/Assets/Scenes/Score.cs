using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Tim Gijzen
    //Set this on the UI

    //Set UI text in here 
    public Text lifeDisplay;

    //The score
    public float CurrentScore;

    //Get-set from LevelCountdown Script
    public float RemTime;

    //Get-set from EnemyAI Script
    public float EnemyDead;

    //Set LevelCountdown and EnemyAI on this gameobject to let this script work
    public GameObject ScriptManager;

    void Update()
    {
        //Get values from other scripts script = <>
        RemTime = ScriptManager.GetComponent<LevelCountdown>().remainingtime;
      //  EnemyDead = ScriptManager.GetComponent<EnemyAI>().EnemiesDead;

        //RemTime for every second left +10 score
        //EnemyDead for every Enemy dead +35 score
        CurrentScore = RemTime * 10f + EnemyDead * 35f;

        //set score to : Score: CurrentScore
        lifeDisplay.text = ("Score: ")+CurrentScore.ToString();
    }
}
