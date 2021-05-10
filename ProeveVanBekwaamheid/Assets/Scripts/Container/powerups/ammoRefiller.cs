using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoRefiller : MonoBehaviour
{

    private GameObject gameObject;
    // Update is called once per frame
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag.Equals("Ground") == true)
        {
            gameObject.GetComponent<ammoManager>().ammoRefill();

        }
    }
}
