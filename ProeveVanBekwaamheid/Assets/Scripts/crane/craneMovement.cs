//Suryani
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craneMovement : MonoBehaviour
{
    [SerializeField] private GameObject Pivot;
    [SerializeField] private GameObject Boom;
    [SerializeField] private GameObject Pulley;
    [SerializeField] private GameObject Rope;
    [SerializeField] private GameObject Magnet;
    [SerializeField] private Vector2 minMaxBoomAngle = new Vector2(290, 340);
    [SerializeField] private Vector2 minMaxBoomLength = new Vector2(200, 350);
    //Needs to be tweaked for final level position
    [SerializeField] private Vector2 minMaxRotation = new Vector2(240, 360);
    [SerializeField] private float boomSpeed = 0.2f, boomExtensionSpeed = 0.2f;
    [SerializeField] private float rotateSpeed = 0.2f;
    [SerializeField] private float winchSpeed = 0.02f;
    [SerializeField] private float winchMin = 20f, winchMax = 5000f;
    private float ropeLength;

    //(Dexter) Value accesed by ControlsManager.cs
    public bool craneControlsActive = false;

    private void Start()
    {
        ropeLength = Rope.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        //(Dexter) Added craneControlsActive check so that we can disable and enable the controls using ControlsManager.cs
        if (Input.GetKey("w") && craneControlsActive == true) boomLift(1);
        if (Input.GetKey("s") && craneControlsActive == true) boomLift(-1);
        if (Input.GetKey("a") && craneControlsActive == true) rotateCrane(-1);
        if (Input.GetKey("d") && craneControlsActive == true) rotateCrane(1);
        if (Input.GetKey("q") && craneControlsActive == true) winch(1);
        if (Input.GetKey("e") && craneControlsActive == true) winch(-1);
        if (Input.GetKey(KeyCode.LeftShift) && craneControlsActive == true) boomExtension(1);
        if (Input.GetKey(KeyCode.LeftControl) && craneControlsActive == true) boomExtension(-1);
    }

    void boomExtension(short dir)
    {
        Vector3 orPulleyPos = Pulley.transform.position;
        float length = Boom.transform.localScale.y + boomExtensionSpeed * dir;
        length = Mathf.Clamp(length, minMaxBoomLength.x, minMaxBoomLength.y);
        Boom.transform.localScale = new Vector3(
            Boom.transform.localScale.x,
            length,
            Boom.transform.localScale.z
        );
        // Move Rope and Magnet with the Pulley
        Vector3 pulleyDelta = Pulley.transform.position - orPulleyPos;
        Rope.transform.position = Rope.transform.position + pulleyDelta;
        Magnet.transform.position = Magnet.transform.position + pulleyDelta;
    }

    void winch(short dir)
    {
        //Extend rope
        float orRopeLength = ropeLength;
        ropeLength += winchSpeed * dir;
        ropeLength = Mathf.Clamp(ropeLength, winchMin, winchMax);
        float delta = orRopeLength - ropeLength;
        Rope.transform.localScale = new Vector3(
            Rope.transform.localScale.x,
            Rope.transform.localScale.y,
            ropeLength
        );
        Magnet.transform.position = new Vector3(
            Magnet.transform.position.x,
            Magnet.transform.position.y + delta / 50f,
            Magnet.transform.position.z
        );
    }

    void boomLift(short dir)
    {
        Vector3 orPulleyPos = Pulley.transform.position;
        // Compute delta
        float Pitch = Boom.transform.localEulerAngles.x;
        float newPitch = Mathf.Clamp(Pitch + boomSpeed * dir, minMaxBoomAngle.x, minMaxBoomAngle.y);
        float Delta = newPitch - Pitch;
        // Apply the new angle to the boom
        Boom.transform.RotateAround(Pivot.transform.position, Pivot.transform.right, Delta);
        // Move Rope and Magnet with the Pulley
        Vector3 pulleyDelta = Pulley.transform.position - orPulleyPos;
        Rope.transform.position = Rope.transform.position + pulleyDelta;
        Magnet.transform.position = Magnet.transform.position + pulleyDelta;
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
