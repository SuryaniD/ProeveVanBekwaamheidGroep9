using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gotoInstructions : MonoBehaviour
{
        public void NextScene()
        {
            SceneManager.LoadScene("Instructions");
        }
    }

