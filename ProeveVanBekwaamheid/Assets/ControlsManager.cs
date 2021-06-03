//Dexter Krijgsman
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    //Public links to the scripts so that we can change the variables from the other scripts here.
    public WaterCanon waterCanon;
    public craneMovement CraneMovement;

    // Start is called before the first frame update
    void Start()
    {
        waterCanon.waterControlsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Makes it so that when the key "q" is pressed the controls switch from crane to canon and other way around.
        if (Input.GetKeyDown("q"))
        {
            if (CraneMovement.craneControlsActive == false)
            {
                CraneMovement.craneControlsActive = true;
                waterCanon.waterControlsActive = false;
            }

            else if (CraneMovement.craneControlsActive == true)
            {
                CraneMovement.craneControlsActive = false;
                waterCanon.waterControlsActive = true;
            }
        }
    }
}
