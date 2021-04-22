//Tim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomLevelGenerator : MonoBehaviour
{
    //MapTile list for premade tiles(specific prebuild mapparts for specific locations)
    public GameObject[] mapTileSet1;
    public GameObject[] mapTileSet2;
    public GameObject[] mapTileSet3;
    public GameObject[] mapTileSet4;
    public GameObject[] mapTileSet5;
    public GameObject[] mapTileSet6;
    public GameObject[] mapTileSet7;
    public GameObject[] mapTileSet8;
    public GameObject[] mapTileSet9;

    //Location where object spawns(placed empty object for vector3)
    public GameObject[] tileLocations;

    //Final Map
    public GameObject madeMap;

    void Start()
    {    
        // Spawns Maptile - select out list random - set on specified location by empty object(placed in game) - adds to mademap as child
        Instantiate(mapTileSet1[Random.Range(1, 4)], tileLocations[0].transform.position, Quaternion.Euler(-90, 0, 0)).transform.parent = madeMap.transform;
        Instantiate(mapTileSet2[Random.Range(1, 4)], tileLocations[1].transform.position, Quaternion.Euler(-90, 0, 0)).transform.parent = madeMap.transform;
        Instantiate(mapTileSet3[Random.Range(1, 4)], tileLocations[2].transform.position, Quaternion.Euler(-90, 0, 0)).transform.parent = madeMap.transform;
        Instantiate(mapTileSet4[Random.Range(1, 4)], tileLocations[3].transform.position, Quaternion.Euler(-90, 0, 0)).transform.parent = madeMap.transform;
        Instantiate(mapTileSet5[Random.Range(1, 4)], tileLocations[4].transform.position, Quaternion.Euler(-90, 0, 0)).transform.parent = madeMap.transform;
        Instantiate(mapTileSet6[Random.Range(1, 4)], tileLocations[5].transform.position, Quaternion.Euler(-90, 0, 0)).transform.parent = madeMap.transform;
        Instantiate(mapTileSet7[Random.Range(1, 4)], tileLocations[6].transform.position, Quaternion.Euler(-90, 0, 0)).transform.parent = madeMap.transform;
        Instantiate(mapTileSet8[Random.Range(1, 4)], tileLocations[7].transform.position, Quaternion.Euler(-90, 0, 0)).transform.parent = madeMap.transform;
        Instantiate(mapTileSet9[Random.Range(1, 4)], tileLocations[8].transform.position, Quaternion.Euler(-90, 0, 0)).transform.parent = madeMap.transform;
    }
}
