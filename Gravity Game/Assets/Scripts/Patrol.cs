using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public Transform[] points;

    private int pointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[pointIndex].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, points[pointIndex].position) < 0.2f)
        {
            pointIndex++;
            if (pointIndex >= points.Length)
            {
                pointIndex = 0;
            }
        }
    }
}
