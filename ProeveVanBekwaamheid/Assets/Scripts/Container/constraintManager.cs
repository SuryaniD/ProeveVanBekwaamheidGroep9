//made by toon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The point of this script is to alter how the container behaves depending on what it collides with.
public class constraintManager : MonoBehaviour
{
    public GameObject effect;
    private Rigidbody rigidBody;
    private bool stackedObject;
    private int destroyTimer = 10;

    void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        stackedObject = false;
        rigidBody.mass = 100;
    }

    void OnCollisionEnter(Collision collider)
    {
       if (collider.gameObject.tag.Equals("Container") == true)
           
       {
            /*The positions X and Z are disabled so that if the container doesnt perfectly land on the other container, it doesn't automatically fall off. This'll make gameplay and placing 
              containers less frustrating*/

            /*the code for rotation constraints is repeated multiple times because whenever a new line is executed where constrains are enabled, it disables the constraints done in a previous
              line of code.*/  
            //rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            stackedObject = true;
       }
        

        if (collider.gameObject.tag.Equals("Ground"))
        {
            transform.gameObject.tag = "ContainerGrounded";
            // Does not work
            //Instantiate(effect, transform.position, transform.rotation);
            //Destroy(effect, 3);
        }

        if (collider.gameObject.tag.Equals("Crane"))
        {
            transform.gameObject.tag = "Container";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //when no collision is made, all the other contraints reset, besides the two rotations
        rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }

}


