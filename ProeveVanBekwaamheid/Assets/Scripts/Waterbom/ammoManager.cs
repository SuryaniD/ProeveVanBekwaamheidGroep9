//toon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoManager : MonoBehaviour
{
   public int ammo = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ammo = ammo - 1;
        }

        if(ammo == 0)
        {
            GetComponent<PredictedProjectile>().enabled = false;
        }
    }

    public void ammoRefill()
    {
        ammo = ammo + 5;
    }
}
