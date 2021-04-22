//Tim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addExtras : MonoBehaviour
{
    public GameObject[] allContainers;
    public GameObject[] colliderHoldingList;
    public GameObject moreCollider;
    public Material[] addMaterials;
    public float wFS = 0.3f;
    public float startWait = 0.4f;


    void Start()
    {
        waitForSpawn();
        spawnWaves();
    }

    IEnumerator waitForSpawn()
    {
        yield return new WaitForSeconds(wFS);
        allContainers = GameObject.FindGameObjectsWithTag("Container");
    }

    IEnumerator spawnWaves()
    {
        
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < allContainers.Length; i++)
        {
         
            colliderHoldingList[i] = Instantiate(moreCollider);
            allContainers[i].transform.parent = colliderHoldingList[i].transform;
            allContainers[i].GetComponent<MeshRenderer>().material = addMaterials[Random.Range(0, 3)];
        }
    }
}
