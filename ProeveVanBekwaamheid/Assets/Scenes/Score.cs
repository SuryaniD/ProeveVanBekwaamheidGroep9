using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float CurrentScore;

    //Get-set from LevelCountdown Script
    public float RemTime;

    //Get-set from EnemyAI Script
    public int EnemyDead;

    void Start()
    {
        
    }

 
    void Update()
    {
        //RemTime = gameObject.GetComponent<LevelCountdown>().RemainingTime;
        //EnemyDead = gameObject.GetComponent<EnemyAI>().EnemiesDead;

        //RemTime for every second left +10 score
        

        //EnemyDead for every Enemy dead +35 score




    }
}
