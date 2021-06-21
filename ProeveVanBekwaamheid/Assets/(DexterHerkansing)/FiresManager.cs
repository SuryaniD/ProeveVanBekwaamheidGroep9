using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresManager : MonoBehaviour
{
    //Reference to the lives scripts
    public Lives lives;

    //Public array of fireSpawnPlaces in the scene to know where to spawn fires
    public GameObject[] fireSpawnPlaces;
    public GameObject firePrefab;

    private GameObject startFires;

    [SerializeField]
    private int startFiresAmount = 1;
    private int fireSpawnIndex;

    [HideInInspector]
    public float timeLeft = 60;
    // Start is called before the first frame update
    void Start()
    {
        //Fills the FireSpawnPlaces array at the start with all the empty spawn location in the level to know where to spawn fires
        fireSpawnPlaces = GameObject.FindGameObjectsWithTag("FireSpawnPlace");
        lives = GetComponent<Lives>();
        //For loop that loops for the amount of fires that need to start at the starts
        for (int i = 0; i < startFiresAmount; i++)
        {
            SpawnFireRandom();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Lowers the timeleft and after 60 seconds executes LowerHealth() from the Lives script
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            lives.LowerHealth();
            timeLeft = 60;
        }
    }

    //This function starts spawnFireRandom() to prevent out of index errors
    public void StartNewFires()
    {
        SpawnFireRandom();
    }

    //Takes a random gameobject transform from the firespawnplaces[] array to spawn new fires
    private void SpawnFireRandom()
    {
        fireSpawnPlaces = GameObject.FindGameObjectsWithTag("FireSpawnPlace");
        fireSpawnIndex = Random.Range(0, fireSpawnPlaces.Length);
        startFires = fireSpawnPlaces[fireSpawnIndex];
        Instantiate(firePrefab, startFires.transform);
    }
}
