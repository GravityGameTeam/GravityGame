﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollControl : MonoBehaviour
{
    public float startPosition;
    public float leftLimit;
    public float rightLimit;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);

        if (transform.position.x < leftLimit)
        {
            transform.position = new Vector3(leftLimit, transform.position.y, 100);
        } else if (transform.position.x > rightLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, 100);
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(startPosition, transform.position.y, 100);
    }
}
