using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour
{
    public GameObject[][] MapTile;
    public GameObject[] TileLocations;

    public GameObject MadeMap;

    void Start()
    {
        
    }


    void Update()
    {
        Debug.Log(Random.Range(1,4));




    }
}
