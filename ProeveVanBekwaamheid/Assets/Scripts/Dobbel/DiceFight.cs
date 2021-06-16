using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFight : MonoBehaviour
{

    public DobbelManager dobbelManager;
    [SerializeField]
    private GameObject[] enemyPiratesArray;

    private GameObject playerChar;

    private int newDmgPlayer;
    private int oldDmgPlayer;
    private int newDmgEnemy;
    private int oldDmgEnemy;

    private int playerHealth = 50;
    private int enemyHealth = 6;

    private int hasThrown = 0;
    private int hasThrownEnemy = 0;

    public int piratesDestroyed = 0;


    void Start()
    {
        enemyPiratesArray = dobbelManager.enemyPirate;
        playerChar = dobbelManager.questPlayer;
    }
    

    void Update()
    {
        newDmgPlayer = dobbelManager.hitDmg;
        newDmgEnemy = dobbelManager.enemyHitDmg;

        if (oldDmgPlayer != newDmgPlayer)
        {
            hasThrown++;
            oldDmgPlayer = newDmgPlayer;
        }


        if(oldDmgEnemy != newDmgEnemy)
        {
            hasThrownEnemy++;
            oldDmgEnemy = newDmgEnemy;
        }


        if(hasThrown >= 1)
        {
            hasThrown--;

            enemyHealth = enemyHealth - oldDmgPlayer;
            Debug.Log(hasThrown);
        }

        if (hasThrownEnemy >= 1)
        {
            hasThrownEnemy--;

            playerHealth = playerHealth - oldDmgEnemy;
            Debug.Log(hasThrownEnemy);
        }

        if (playerHealth <= 0)
        {
            Destroy(playerChar);
        }

        if(enemyHealth <= 0)
        {
            enemyHealth = 6;
            Destroy(enemyPiratesArray[piratesDestroyed]);
            piratesDestroyed++;
        }
    }
}
