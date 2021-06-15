using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBullet : MonoBehaviour
{
    public GameObject explodableObject;
    private float entry = 30000.0f;
    private float radius = 30.0f;

    void OnCollisionEnter(Collision collision)
    {
        //When the bom collides, it creates the explosion effect. Then deletes the bomb and deletes the explosion effect three seconds later
        //GameObject explodingObject = Instantiate(explodableObject, transform.position, transform.rotation);
        //Destroy(explodableObject, 3);
        knockBack();
        Destroy(gameObject);     
    }

    void knockBack()
    {
        //Captures all the nearby colliders using a radius
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObjects in colliders)
        {
            Rigidbody rigidbody = nearbyObjects.GetComponent<Rigidbody>();
            if(rigidbody != null)
            {
                //first two elements are looking for where the explosion is going start, the third looks for how big the explosion is going to be
                rigidbody.AddExplosionForce(entry, transform.position, radius);
            }
        }
    }
}
