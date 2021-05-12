using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoRefiller : MonoBehaviour
{
    private ammoManager ammoManager;
    // Update is called once per frame
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag.Equals("Ground") == true)
        {
            GetComponent<PredictedProjectile>().enabled = true;
            GetComponent<ammoManager>().enabled = true;
            ammoManager.ammo = ammoManager.ammo + 5;
        }
    }
}
