using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoManager : MonoBehaviour
{
    int ammo = 5;

    GameObject gameObject;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ammo = ammo - 1;
        }

        if(ammo == 0)
        {
            Debug.Log("disabled");
            GetComponent<PredictedProjectile>().enabled = false;
        }
    }
}
