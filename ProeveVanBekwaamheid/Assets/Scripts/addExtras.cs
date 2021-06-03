//Tim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddExtras : MonoBehaviour
{
    //lists en object holder.
    public GameObject[] allContainers;
    public GameObject[] colliderHoldingList;
    public GameObject[] allChilds;
    public GameObject moreCollider;
    //Material list.
    public Material[] addMaterials;
  

    void Start()
    {
        //Finds all objects with containertag and adds them to allContainers[].
        allContainers = GameObject.FindGameObjectsWithTag("Container");
        allChilds = GameObject.FindGameObjectsWithTag("Unchild");
        //Function call.
        addMaterialsAndColliders();
    }

   
    public void addMaterialsAndColliders()
    {
        for (int i = 0; i < allContainers.Length; i++)
        {
            //Gives allContainers a random material (addMaterials x4)
            allContainers[i].GetComponent<MeshRenderer>().material = addMaterials[Random.Range(0, 5)];
           
        }
        for (int j = 0; j < allChilds.Length; j++)
        {
            //Removes children from parents (they become parents themself)
            allChilds[j].transform.parent = null;
        }
        }
    
}