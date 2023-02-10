using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruits : MonoBehaviour
{
    //counting
    private int orange = 0;
    //สตภýปฏ
    [SerializeField] private Text orangeText;
    //Eating Orange
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Orange"))
        {
            Destroy(collision.gameObject);
            orange++;
            Debug.Log("Oranges: " + orange);
            //UI-info
            orangeText.text = "Oranges: " + orange;
        }
    }
}
