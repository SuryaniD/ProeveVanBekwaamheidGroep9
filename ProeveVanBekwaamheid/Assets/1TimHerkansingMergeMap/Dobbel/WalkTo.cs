//Tim Gijzen
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

    private bool stopWalking = false;

    void Start()
    {
        walkSpeed = Speed * Time.deltaTime;
    }
    
    void Update()
    {
        //Move too location and rotate towards, enemy gets destroyed walks to next, when done then stops updating 
        pdestroyed = diceFight.piratesDestroyed;
        if(pdestroyed == 4 && stopWalking == false)
        {
            stopWalking = true;
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[3].transform.position, walkSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, wayPoints[3].transform.rotation, Time.deltaTime * smooth);
        }
        if (stopWalking == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[pdestroyed].transform.position, walkSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, wayPoints[pdestroyed].transform.rotation, Time.deltaTime * smooth);
        }
        
    }
}
