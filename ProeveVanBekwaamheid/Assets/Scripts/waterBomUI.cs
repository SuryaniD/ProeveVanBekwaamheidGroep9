//toon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waterBomUI : MonoBehaviour
{
    public Text ammoText;
    int currentAmount = 5;
   
    void Update()
    {
        ammoText.text = ("Bom Ammo: ") + currentAmount.ToString();
    

    if (Input.GetMouseButtonDown(0))
        {
        currentAmount = currentAmount - 1;   
        }

    if (currentAmount < 0)
        {
        currentAmount = 0;
        }
    }
}

