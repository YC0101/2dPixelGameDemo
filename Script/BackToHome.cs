using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Load Scene

public class BackToHome : MonoBehaviour
{
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
