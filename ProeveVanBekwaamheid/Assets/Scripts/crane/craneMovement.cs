//Suryani
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craneMovement : MonoBehaviour
{
    [SerializeField] private GameObject Pivot;
    [SerializeField] private GameObject Boom;
    [SerializeField] private Vector2 minMaxBoomAngle = new Vector2(290, 340);
    //Needs to be tweaked for final level position
    [SerializeField] private Vector2 minMaxRotation = new Vector2(240, 360);
    [SerializeField] private float boomSpeed = 0.2f;
    [SerializeField] private float rotateSpeed = 0.2f;



    // Update is called once per frame
    void Update()
    {
        //Placeholder, needs to be controlled with controller script
        if (Input.GetKey("w")) boomLift(1);
        if (Input.GetKey("s")) boomLift(-1);
        if (Input.GetKey("a")) rotateCrane(-1);
        if (Input.GetKey("d")) rotateCrane(1);
    }

    void boomLift(short dir)
    {
        // Compute delta
        float Pitch = Boom.transform.localEulerAngles.x;
        float newPitch = Mathf.Clamp(Pitch + boomSpeed * dir, minMaxBoomAngle.x, minMaxBoomAngle.y);
        float Delta = newPitch - Pitch;
        // Apply the new angle
        Boom.transform.RotateAround(Pivot.transform.position, Pivot.transform.right, Delta);
    }

    void rotateCrane(short dir)
    {
        // Compute delta
        float Yaw = Pivot.transform.localEulerAngles.y;
        float newYaw = Mathf.Clamp(Yaw + rotateSpeed * dir, minMaxRotation.x, minMaxRotation.y);
        float Delta = newYaw - Yaw;
        // Apply the new angle
        Pivot.transform.RotateAround(Pivot.transform.position, Pivot.transform.up, Delta);
    }
}
