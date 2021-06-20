//Tim Gijzen
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

    public int piratesDestroyed = 0;

    public bool rolledPlayer;
    public bool rolledEnemy;

    void Start()
    {
        enemyPiratesArray = dobbelManager.enemyPirate;
        playerChar = dobbelManager.questPlayer;
    }
    

    void Update()
    {
        newDmgPlayer = dobbelManager.hitDmg;
        newDmgEnemy = dobbelManager.enemyHitDmg;

        rolledPlayer = dobbelManager.diceWasRolledPlayer;
        rolledEnemy = dobbelManager.diceWasRolledEnemy;

        //enemy hp is one hp adds it back. adds score and start to walk to next enemy(and plays deathsound)
        if (enemyHealth <= 0)
        {
            enemyHealth = 6;
            enemyPiratesArray[piratesDestroyed].transform.Find("DeathSound").gameObject.GetComponent<AudioSource>().Play();
            score.enemyDead++;
            StartCoroutine(WaitForWalk());
        }

        //player hp 0 destroy player
        if (playerHealth <= 0)
        {
            Destroy(playerChar);
        }

        //Checks if new dmg to Enemy is rolled and subtrackts it from Enemy hp
        if (rolledPlayer == true)
        {
            rolledPlayer = false;
            oldDmgPlayer = newDmgPlayer;
            enemyHealth = enemyHealth - oldDmgPlayer;
        }

        //Checks if new dmg to player is rolled and subtrackts it from player hp
        if(rolledEnemy == true)
        {
            rolledEnemy = false;
            oldDmgEnemy = newDmgEnemy;
            playerHealth = playerHealth - oldDmgEnemy;
        }
       
    }
    //Gives player time to walk before next enemy starts rolling
    IEnumerator WaitForWalk()
    {
        yield return new WaitForSeconds(2f);
        Destroy(enemyPiratesArray[piratesDestroyed]);
        piratesDestroyed++;
    }
}
