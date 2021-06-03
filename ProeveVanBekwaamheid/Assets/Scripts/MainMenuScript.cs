//Tim Gijzen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    void Update()
    {
        //rotates on Y
        transform.Rotate(0, 0.013f, 0 * Time.deltaTime);
        //Presses any key to change scene
        if (Input.anyKey)
        {
           SceneManager.LoadScene (sceneName:"CraneFixPrototype");
        }
    }
}
