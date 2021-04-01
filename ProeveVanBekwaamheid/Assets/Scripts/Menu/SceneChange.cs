using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public int timer = 1;

    public void Switcher()
    {
        timer = timer -= 1;
        if (timer == 0)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
