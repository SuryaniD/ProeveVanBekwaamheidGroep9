using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMove : MonoBehaviour
{
    int speed = 10;
        
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
    }
    }

