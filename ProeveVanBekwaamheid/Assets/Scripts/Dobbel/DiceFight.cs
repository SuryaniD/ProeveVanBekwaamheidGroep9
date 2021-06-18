using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFight : MonoBehaviour
{

    public ammoManager aManager;
    public DobbelManager dobbelManager;
    public Score score;

    private GameObject[] enemyPiratesArray;

    private GameObject playerChar;

    private int newDmgPlayer;
    private int oldDmgPlayer;
    private int newDmgEnemy;
    private int oldDmgEnemy;

    public int playerHealth = 50;
    public int enemyHealth = 6;

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
            enemyPiratesArray[piratesDestroyed].transform.Find("DeathSound").gameObject.GetComponent<AudioSource>().Play();
            enemyHealth = 6;
            score.enemyDead++;
            StartCoroutine(WaitForWalk());
        }
       
    }
    IEnumerator WaitForWalk()
    {
        yield return new WaitForSeconds(2f);
        Destroy(enemyPiratesArray[piratesDestroyed]);
        piratesDestroyed++;
    }
}
