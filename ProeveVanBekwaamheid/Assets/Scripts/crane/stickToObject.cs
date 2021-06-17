//Base script by Toon, additons made by Suryani to make it work
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickToObject : MonoBehaviour
{
    private GameObject collidingObject = null;
    private FixedJoint joint;
    


    void OnCollisionEnter(Collision col)
    {
        
        if ((col.gameObject.tag.Equals("Container") || col.gameObject.tag.Equals("Unchild")) || (col.gameObject.tag.Equals("ContainerGrounded")) && collidingObject == null)
        {
            collidingObject = col.contacts[0].otherCollider.gameObject;
            collidingObject.GetComponent<Rigidbody>().isKinematic = true;
            collidingObject.transform.SetParent(gameObject.transform);
           
            
        }

    }
   
    private void Update()
    {
        //Needs to be pressed somewhat longer to work
        if (Input.GetKey(KeyCode.Space) && collidingObject != null)
        {
            //Detach object from magnet & reanble physics
            collidingObject.transform.SetParent(null);
            collidingObject.GetComponent<Rigidbody>().isKinematic = false;
            collidingObject = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}



 