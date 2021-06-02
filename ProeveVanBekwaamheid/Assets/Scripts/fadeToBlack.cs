using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeToBlack : MonoBehaviour
{
    public GameObject fade;
    public void fadeOut()
    {
        fade.GetComponent<Animation>().Play("fade");
    }
}
