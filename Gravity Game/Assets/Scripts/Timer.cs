using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public float timeElapsed;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Time.time - startTime;

        string minutes = ((int) timeElapsed / 60).ToString();
        string seconds = (timeElapsed % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    public float getTimeElapsed()
    {
        return timeElapsed;
    }
}
