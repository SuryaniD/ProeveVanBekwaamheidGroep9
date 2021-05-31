//Suryani
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaterCanon : MonoBehaviour
{
    [SerializeField] private GameObject Boat;
    [SerializeField] private GameObject WaterHose;
    [SerializeField] private GameObject WaterBullet;
    [SerializeField] private GameObject SprayPrefab;
    [SerializeField] private Vector2 minMaxYaw;
    [SerializeField] private Vector2 minMaxPitch;
    [SerializeField] private Vector2 speedYawPitch;
    [SerializeField] private float bulletSpawnDelta = 0.1f;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private Vector3 sprayOffst = new Vector3(1.5f, 0, 0);

    private GameObject spray;
    private Queue<GameObject> bullets = new Queue<GameObject>();
    private Vector3 bulletOffst = new Vector3(1, 0, 0); 
    private double lastSpawnTime = 0;
    private int Velocity;
    private bool IsFiring { get; set; }

    public bool waterControlsActive = true;

    // Start is called before the first frame update
    void Start()
    {
        // Place spray at the end of the gun
        Vector3 pos = WaterHose.transform.position;
        Vector3 ofst = WaterHose.transform.forward * sprayOffst.x + WaterHose.transform.right * sprayOffst.y + WaterHose.transform.up * sprayOffst.z;
        pos = pos + ofst;
        spray = Instantiate(SprayPrefab, pos, WaterHose.transform.rotation, WaterHose.transform);
        spray.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Needs to be changed to be controlled with controllers script
        if (Input.GetKeyDown("f") && waterControlsActive == true) Shoot();
        if (Input.GetKey("a") && waterControlsActive == true) turnYaw(-1);
        if (Input.GetKey("d") && waterControlsActive == true) turnYaw(1);
        if (Input.GetKey("w") && waterControlsActive == true) turnPitch(-1);
        if (Input.GetKey("s") && waterControlsActive == true) turnPitch(1);

        // Water bullets
        if (spray.activeSelf)
        {
            if (Time.realtimeSinceStartup - lastSpawnTime > bulletSpawnDelta)
            {
                // Place bullet at the end of the gun
                Vector3 pos = WaterHose.transform.position;
                Vector3 ofst = WaterHose.transform.forward * bulletOffst.x + WaterHose.transform.right * bulletOffst.y + WaterHose.transform.up * bulletOffst.z;
                pos = pos + ofst;
                GameObject bullet = Instantiate(WaterBullet, pos, WaterHose.transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(WaterHose.transform.forward * bulletSpeed);
                bullets.Enqueue(bullet);
                // Update time
                lastSpawnTime = Time.realtimeSinceStartup;
            }

        } else
        {
            while (bullets.Count > 0)
            {
                GameObject bullet = bullets.Dequeue();
                if (bullet != null) Destroy(bullet);
            }
        }
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
        spray.SetActive(!spray.activeSelf);
    }
}
