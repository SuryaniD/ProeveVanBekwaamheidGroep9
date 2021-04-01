//Toon
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void NextScene(string scene)
    {
        {
           StartCoroutine(LaunchScene(scene));
        }
        //We're using an Enumerator so that a timer can be added to the script. This will give the fade animation enough time to play until the next scene loads
        IEnumerator LaunchScene(string Game)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(Game);
        }
    }
}
