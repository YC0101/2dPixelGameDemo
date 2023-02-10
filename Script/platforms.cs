using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platforms : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private float speed = 2f;

    private int pointNum = 1;//which point the object hit

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[pointNum].transform.position, speed*Time.deltaTime);
        if(Vector2.Distance(transform.position, points[pointNum].transform.position) < 0.1f)
        {
            pointNum++;
            if(pointNum >= points.Length)
            {
                pointNum = 0;
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                pointNum = 1;
                transform.localScale = new Vector2(-1, 1);
            }
        }
    }
}
