//toj
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
            //Whenever the container hits the ground it adds 5 extra bullets. That means that even after it has already hit the ground, if it flips over it'll add another 5 bullets.
            //So deleting it on collision seemed like the best way to fix that
            Destroy(gameObject);
            }
        }
    }

