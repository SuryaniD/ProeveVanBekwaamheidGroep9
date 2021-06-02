using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class goToGame : MonoBehaviour
{
    public void NextScene()
    {
       SceneManager.LoadScene("CraneFixPrototype");
    }
}