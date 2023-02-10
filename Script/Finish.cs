using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//scene

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            finishSound.Play();
            Invoke("finishLevel", 0.5f);
            //finishLevel();
        }

    }

    private void finishLevel()
    {
        SceneManager.LoadScene(2);
    }
}
