//Tim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addExtras : MonoBehaviour
{
    //lists en object holder.
    public GameObject[] allContainers;
    public GameObject[] colliderHoldingList;
    public GameObject moreCollider;
    //Material list.
    public Material[] addMaterials;


    void Start()
    {
        //Finds all objects with containertag and adds them to allContainers[].
        allContainers = GameObject.FindGameObjectsWithTag("Container");
        //Function call.
        addMaterialsAndColliders();
    }

   
    public void addMaterialsAndColliders()
    {
        for (int i = 0; i < allContainers.Length; i++)
        {
            //Needs a better solution becouse it needs to give 1 collider instead of 3 (doors also have tag container so collider spawns on that too).
              //  colliderHoldingList[i] = Instantiate(moreCollider);
              //  allContainers[i].transform.parent = colliderHoldingList[i].transform;
            //Gives allContainers a random material (addMaterials x4)
            allContainers[i].GetComponent<MeshRenderer>().material = addMaterials[Random.Range(0, 4)];
            Debug.Log("4");
        }
    }
    
}