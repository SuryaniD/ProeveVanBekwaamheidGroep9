using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFight : MonoBehaviour
{

    public ammoManager aManager;
    public DobbelManager dobbelManager;
    public Score score;

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
        }

        if (hasThrownEnemy >= 1)
        {
            hasThrownEnemy--;

            playerHealth = playerHealth - oldDmgEnemy;
        }

        if (playerHealth <= 0)
        {
            Destroy(playerChar);
        }

        if(enemyHealth <= 0)
        {
            enemyHealth = 6;
            Destroy(enemyPiratesArray[piratesDestroyed]);
            score.enemyDead++;
            StartCoroutine(WaitForWalk());
        }

        if (piratesDestroyed == 4)
        {
            ammoManager.ammo = ammoManager.ammo + 5;
        }
       
    }
    IEnumerator WaitForWalk()
    {
        yield return new WaitForSeconds(5.5f);
        piratesDestroyed++;
    }
}
