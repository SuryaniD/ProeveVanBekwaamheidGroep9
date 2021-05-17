using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoRefiller : MonoBehaviour
{
    private GameObject finder;

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag.Equals("Ground") == true)
        {
            GameObject.FindGameObjectWithTag("WaterCanon").GetComponent<PredictedProjectile>().enabled = true;
            ammoManager.ammo = ammoManager.ammo + 5;
            Destroy(gameObject);
            }
        }
    }

