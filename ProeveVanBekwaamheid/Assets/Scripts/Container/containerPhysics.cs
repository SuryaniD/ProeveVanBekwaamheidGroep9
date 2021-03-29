//made by toon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class containerPhysics : MonoBehaviour
{
    private Rigidbody rigidbody;
    private bool isGrounded;

    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        //leaving these two active will only make pushing the container with the watercannon more frustrating, so they'll always be turned off
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded = false)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
    }
}


