using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoRefiller : MonoBehaviour
{
    private GameObject finder;
    // Update is called once per frame
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag.Equals("Ground") == true)
        {
            GameObject.FindGameObjectWithTag("WaterCanon").GetComponent<PredictedProjectile>().enabled = true;
            GameObject.FindGameObjectWithTag("WaterCanon").GetComponent<ammoManager>();

            if (ammoManager.ammo == 5)
            {
                ammoManager.ammo = ammoManager.ammo + 0;
            }
            else
            {
                ammoManager.ammo = ammoManager.ammo + 5;
            }
        }
    }
}
