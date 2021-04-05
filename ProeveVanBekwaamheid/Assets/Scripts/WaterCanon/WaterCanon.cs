//Suryani
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaterCanon : MonoBehaviour
{
    [SerializeField] private GameObject Boat;
    [SerializeField] private GameObject WaterHose;
    [SerializeField] private GameObject Ball;
    [SerializeField] private Vector2 minMaxYaw;
    [SerializeField] private Vector2 minMaxPitch;
    [SerializeField] private Vector2 speedYawPitch;

    private Vector3 bulletOffst = new Vector3(1, 0, 0);
    private int Velocity;
    private bool IsFiring { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("f")) 
        {
            Shoot();
        }
        if (Input.GetKey("a")) turnYaw(-1);
        if (Input.GetKey("d")) turnYaw(1);
        if (Input.GetKey("w")) turnPitch(-1);
        if (Input.GetKey("s")) turnPitch(1);
    }

    void turnYaw(short dir)
    {
        // Calculate water gun angle relative to boat
        Quaternion quat = WaterHose.transform.rotation * Quaternion.Inverse(Boat.transform.rotation);
        float delta = quat.eulerAngles.y;
        // Ensure the delta angle is in range -180/180 instead of 0/360
        if (delta > 180) delta = delta - 360f;
        // Turn Gun
        delta += speedYawPitch.x * dir;
        delta = Mathf.Clamp(delta, minMaxYaw.x, minMaxYaw.y);
        // Apply the new angle
        WaterHose.transform.rotation = Quaternion.Euler(
            WaterHose.transform.eulerAngles.x,
            Boat.transform.eulerAngles.y + delta,
            WaterHose.transform.eulerAngles.z
        );
    }

    void turnPitch(short dir)
    {
        // Calculate water gun angle relative to boat
        Quaternion quat = WaterHose.transform.rotation * Quaternion.Inverse(Boat.transform.rotation);
        float delta = quat.eulerAngles.x;
        // Ensure the delta angle is in range -180/180 instead of 0/360
        if (delta > 180) delta = delta - 360f;
        // Turn Gun
        delta += speedYawPitch.y * dir;
        delta = Mathf.Clamp(delta, minMaxPitch.x, minMaxPitch.y);
        // Apply the new angle
        WaterHose.transform.rotation = Quaternion.Euler(
            Boat.transform.eulerAngles.x + delta,
            WaterHose.transform.eulerAngles.y,
            WaterHose.transform.eulerAngles.z
        );
    }

    void Shoot()
    {
        // Place bullet at the end of the gun
        Vector3 pos = WaterHose.transform.position;
        Vector3 ofst = WaterHose.transform.forward * bulletOffst.x + WaterHose.transform.right * bulletOffst.y + WaterHose.transform.up * bulletOffst.z;
        pos = pos + ofst;

        // Instantiate bullet
        Instantiate(Ball, pos, WaterHose.transform.rotation);

    }
}
