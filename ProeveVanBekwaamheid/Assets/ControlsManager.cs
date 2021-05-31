using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public WaterCanon waterCanon;
    public craneMovement CraneMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
