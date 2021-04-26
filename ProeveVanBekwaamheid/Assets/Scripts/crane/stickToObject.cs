using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickToObject : MonoBehaviour
{
    private FixedJoint joint;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Container") == true)
        {
            // creates joint
            joint = gameObject.AddComponent<FixedJoint>();
            // sets joint position to point of contact
            joint.anchor = col.contacts[0].point;
            // conects the joint to the other object
            joint.connectedBody = col.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody>();
            // Stops objects from continuing to collide and creating more joints
            joint.enableCollision = false;
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(joint);
        }
    }

}


 