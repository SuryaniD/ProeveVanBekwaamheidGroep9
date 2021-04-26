using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
    int speed = 10;
    public GameObject predictedPosition;
    public LayerMask layer;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }


    public void Update()
        {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        Ray CamRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(CamRay, out hit, 100f, layer))
        {
            predictedPosition.SetActive(true);
            //Makes the predictPosition follow the mouse 
            predictedPosition.transform.position = hit.point + Vector3.up * 0.1f;

        }
    }
    }
