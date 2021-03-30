using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour
{
    public GameObject[] MapTileSet1;
    public GameObject[] MapTileSet2;
    public GameObject[] MapTileSet3;
    public GameObject[] MapTileSet4;
    public GameObject[] MapTileSet5;
    public GameObject[] MapTileSet6;
    public GameObject[] MapTileSet7;
    public GameObject[] MapTileSet8;
    public GameObject[] MapTileSet9;

    public GameObject[] TileLocations;

    public GameObject MadeMap;

    void Start()
    {
       
        Instantiate(MapTileSet1[Random.Range(1, 4)], TileLocations[1].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        // Instantiate(MapTileSet1[Random.Range(1, 4)], TileLocations[1].transform.position, Quaternion.identity, MadeMap.transform);
        // public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        Instantiate(MapTileSet2[Random.Range(1, 4)], TileLocations[2].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        Instantiate(MapTileSet3[Random.Range(1, 4)], TileLocations[3].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        //4
        //5
        //6
        //7
        //8
        //9


        //Make maptilesets child of MadeMap
       // MapTileSet1[1].transform.parent = MadeMap.transform;

    }


    void Update()
    {
       // Debug.Log(Random.Range(1,4));




    }
}
