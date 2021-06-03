//Suryani
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCountdown : MonoBehaviour
{

    [SerializeField] private GameObject CountdownAsset;
    [SerializeField] private float countdownTime = 10f;
    private float currCountdown = 10f;
    private int minutes = 0;
    private int seconds = 0;
    private float initializationTime;
    public float remainingtime;
    [SerializeField] private int score = 0;
    private Scene scene;

    void Start()
    {
        currCountdown = countdownTime;
        //To check if new level loaded/generated
        initializationTime = Time.timeSinceLevelLoad;
    }

    private void LoadScene(string HighscoreCredits)
    {
        // Get Score
        score = int.Parse(GameObject.Find("Score").GetComponent<Text>().text.Substring(7));
        scene = SceneManager.GetActiveScene();
        // Hook onLoad
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        // Load Next Scene
        SceneManager.LoadScene(HighscoreCredits);
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        // Load score into leaderboard script
        GameObject.Find("Main Camera").GetComponent<LeadboardManager>().score = score;
        SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
    }

    private void Timing()
    {
        float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;

        minutes = Mathf.FloorToInt(currCountdown / 60f);
        seconds = Mathf.FloorToInt(currCountdown % 60f);
        CountdownAsset.GetComponent<Text>().text = minutes.ToString("00") + ":" + seconds.ToString("00");
        if (currCountdown > 0f)
        {
            currCountdown = countdownTime - timeSinceInitialization;
        }
        else
        {
            CountdownAsset.GetComponent<Text>().text = "Tijd is op!";
            LoadScene("HighscoreCredits");

        }

        remainingtime = currCountdown;

    }

    private void EndGame()
    {
        //Search amount of enemies
        int numberOfPirates = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (numberOfPirates == 0)
        {
            LoadScene("HighscoreCredits");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timing();
        EndGame();
    }


}