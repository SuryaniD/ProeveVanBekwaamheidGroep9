using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefab : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 0.5f);
    }
}
