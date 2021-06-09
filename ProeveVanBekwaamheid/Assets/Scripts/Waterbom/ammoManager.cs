//toon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoManager : MonoBehaviour
{
   public static int ammo = 5;
   public Text ammoText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ammo = ammo - 1;
            if(ammo < 0)
            {
                ammo = 0;
            }
        }

        if(ammo == 0)
        {
            GetComponent<PredictedProjectile>().enabled = false;
        }
        
    }
}
