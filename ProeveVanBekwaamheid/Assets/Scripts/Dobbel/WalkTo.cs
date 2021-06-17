using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTo : MonoBehaviour
{
    public DiceFight diceFight;

    [SerializeField]
    private GameObject sQPlayer;

    [SerializeField]
    private GameObject[] wayPoints;

    private float walkSpeed;

    private float Speed = 0.2f;

    private int pdestroyed;

    private float smooth = 1.1f;

    void Start()
    {
        walkSpeed = Speed * Time.deltaTime;
    }
    
    void Update()
    {
        pdestroyed = diceFight.piratesDestroyed;
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[pdestroyed].transform.position, walkSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, wayPoints[pdestroyed].transform.rotation, Time.deltaTime * smooth);
    }
}
