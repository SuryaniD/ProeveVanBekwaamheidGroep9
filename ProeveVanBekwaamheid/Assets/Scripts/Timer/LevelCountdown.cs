using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCountdown : MonoBehaviour
{

    [SerializeField]private GameObject CountdownAsset;
    private float totaltime = 300f;
    private int minutes = 0;
    private int seconds = 0;
    private float initializationTime;

    void Start()
    {
        //To check if new level loaded/generated
        initializationTime = Time.timeSinceLevelLoad;
    }
    private void Timing()
    {
        float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;

        minutes = Mathf.FloorToInt(totaltime / 60f);
        seconds = Mathf.FloorToInt(totaltime % 60f);
        CountdownAsset.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00");
        if (totaltime > 0f) 
        {
            totaltime = 300f - timeSinceInitialization;
        }
        else
        {
            CountdownAsset.GetComponent<Text>().text = "Tijd is op!";
            //Has to be changed to change scenes
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timing();
    }
}
