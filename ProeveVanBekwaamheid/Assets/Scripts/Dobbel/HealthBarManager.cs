using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    public DobbelManager dobbelManager;
    public DiceFight diceFight;

    private GameObject[] enemyPiratesArray;

    [SerializeField]
    private GameObject[] hPE1;
    [SerializeField]
    private GameObject[] hPE2;
    [SerializeField]
    private GameObject[] hPE3;
    [SerializeField]
    private GameObject[] hPE4;

    private GameObject playerChar;

    private int pDestroyed;

    private int eHealth;
    private int pHealth;

    void Start()
    {
        enemyPiratesArray = dobbelManager.enemyPirate;
        playerChar = dobbelManager.questPlayer;
    }

    //Repeating Sets hp blocks render false for how much hp it has
    void Update()
    {
        pDestroyed = diceFight.piratesDestroyed;
        eHealth = diceFight.enemyHealth; 

         if (eHealth == 1 )
        {
            if (pDestroyed == 0)
            {
               hPE1[5].GetComponent<Renderer>().enabled = false;
               hPE1[4].GetComponent<Renderer>().enabled = false;
               hPE1[3].GetComponent<Renderer>().enabled = false;
               hPE1[2].GetComponent<Renderer>().enabled = false;
               hPE1[1].GetComponent<Renderer>().enabled = false;
            }
            if (pDestroyed == 1)
            {
               hPE2[5].GetComponent<Renderer>().enabled = false;
               hPE2[4].GetComponent<Renderer>().enabled = false;
               hPE2[3].GetComponent<Renderer>().enabled = false;
               hPE2[2].GetComponent<Renderer>().enabled = false;
               hPE2[1].GetComponent<Renderer>().enabled = false;
            }
            if (pDestroyed == 2)
            {
               hPE3[5].GetComponent<Renderer>().enabled = false;
               hPE3[4].GetComponent<Renderer>().enabled = false;
               hPE3[3].GetComponent<Renderer>().enabled = false;
               hPE3[2].GetComponent<Renderer>().enabled = false;
               hPE3[1].GetComponent<Renderer>().enabled = false;
            }
             if (pDestroyed == 3)
            {
               hPE4[5].GetComponent<Renderer>().enabled = false;
               hPE4[4].GetComponent<Renderer>().enabled = false;
               hPE4[3].GetComponent<Renderer>().enabled = false;
               hPE4[2].GetComponent<Renderer>().enabled = false;
               hPE4[1].GetComponent<Renderer>().enabled = false;
            }
        }
         if (eHealth == 2 )
        {
            if (pDestroyed == 0)
            {
               hPE1[5].GetComponent<Renderer>().enabled = false;
               hPE1[4].GetComponent<Renderer>().enabled = false;
               hPE1[3].GetComponent<Renderer>().enabled = false;
               hPE1[2].GetComponent<Renderer>().enabled = false;
            }
             if (pDestroyed == 1)
            {
               hPE2[5].GetComponent<Renderer>().enabled = false;
               hPE2[4].GetComponent<Renderer>().enabled = false;
               hPE2[3].GetComponent<Renderer>().enabled = false;
               hPE2[2].GetComponent<Renderer>().enabled = false;
            }
             if (pDestroyed == 2)
            {
               hPE3[5].GetComponent<Renderer>().enabled = false;
               hPE3[4].GetComponent<Renderer>().enabled = false;
               hPE3[3].GetComponent<Renderer>().enabled = false;
               hPE3[2].GetComponent<Renderer>().enabled = false;
            }
             if (pDestroyed == 3)
            {
               hPE4[5].GetComponent<Renderer>().enabled = false;
               hPE4[4].GetComponent<Renderer>().enabled = false;
               hPE4[3].GetComponent<Renderer>().enabled = false;
               hPE4[2].GetComponent<Renderer>().enabled = false;
            }
        }
         if (eHealth == 3 )
        {
            if (pDestroyed == 0)
            {
               hPE1[5].GetComponent<Renderer>().enabled = false;
               hPE1[4].GetComponent<Renderer>().enabled = false;
               hPE1[3].GetComponent<Renderer>().enabled = false;
            }
            if (pDestroyed == 1)
            {
               hPE2[5].GetComponent<Renderer>().enabled = false;
               hPE2[4].GetComponent<Renderer>().enabled = false;
               hPE2[3].GetComponent<Renderer>().enabled = false;
            }
            if (pDestroyed == 2)
            {
               hPE3[5].GetComponent<Renderer>().enabled = false;
               hPE3[4].GetComponent<Renderer>().enabled = false;
               hPE3[3].GetComponent<Renderer>().enabled = false;
            }
             if (pDestroyed == 3)
            {
               hPE4[5].GetComponent<Renderer>().enabled = false;
               hPE4[4].GetComponent<Renderer>().enabled = false;
               hPE4[3].GetComponent<Renderer>().enabled = false;
            }
        }
         if (eHealth == 4 )
        {
                if (pDestroyed == 0)
                {
                hPE1[5].GetComponent<Renderer>().enabled = false;
                hPE1[4].GetComponent<Renderer>().enabled = false;
                }
             if (pDestroyed == 1)
                {
                    hPE2[5].GetComponent<Renderer>().enabled = false;
                    hPE2[4].GetComponent<Renderer>().enabled = false;
                }
             if (pDestroyed == 2)
                {
                    hPE3[5].GetComponent<Renderer>().enabled = false;
                    hPE3[4].GetComponent<Renderer>().enabled = false;
                }
             if (pDestroyed == 3)
                {
                    hPE4[5].GetComponent<Renderer>().enabled = false;
                    hPE4[4].GetComponent<Renderer>().enabled = false;
                }
          }
         if (eHealth == 5 )
       {
                if (pDestroyed == 0)
                {
                    hPE1[5].GetComponent<Renderer>().enabled = false;
                }
             if (pDestroyed == 1)
                {
                    hPE2[5].GetComponent<Renderer>().enabled = false;
                }
             if (pDestroyed == 2)
                {
                    hPE3[5].GetComponent<Renderer>().enabled = false;
                 }
             if (pDestroyed == 3)
                {
                    hPE4[5].GetComponent<Renderer>().enabled = false;
                }
        }
     }
 }


