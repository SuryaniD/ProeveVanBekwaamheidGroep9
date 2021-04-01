using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour
{
    //Tim Gijzen
    //MapTile list for premade tiles(specific prebuild mapparts for specific locations)
    public GameObject[] MapTileSet1;
    public GameObject[] MapTileSet2;
    public GameObject[] MapTileSet3;
    public GameObject[] MapTileSet4;
    public GameObject[] MapTileSet5;
    public GameObject[] MapTileSet6;
    public GameObject[] MapTileSet7;
    public GameObject[] MapTileSet8;
    public GameObject[] MapTileSet9;

    //Location where object spawns(placed empty object for vector3)
    public GameObject[] TileLocations;

    //Final Map
    public GameObject MadeMap;

    void Start()
    {    
        // Spawns Maptile - select out list random - set on specified location by empty object(placed in game) - adds to mademap as child
        Instantiate(MapTileSet1[Random.Range(1, 4)], TileLocations[1].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        Instantiate(MapTileSet2[Random.Range(1, 4)], TileLocations[2].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        Instantiate(MapTileSet3[Random.Range(1, 4)], TileLocations[3].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        Instantiate(MapTileSet4[Random.Range(1, 4)], TileLocations[4].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        Instantiate(MapTileSet5[Random.Range(1, 4)], TileLocations[5].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        Instantiate(MapTileSet6[Random.Range(1, 4)], TileLocations[6].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        Instantiate(MapTileSet7[Random.Range(1, 4)], TileLocations[7].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        Instantiate(MapTileSet8[Random.Range(1, 4)], TileLocations[8].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
        Instantiate(MapTileSet9[Random.Range(1, 4)], TileLocations[9].transform.position, Quaternion.identity).transform.parent = MadeMap.transform;
    }
}
