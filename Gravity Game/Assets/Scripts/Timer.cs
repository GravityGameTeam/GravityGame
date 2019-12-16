using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public float timeElapsed;
    
    private bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            return;
        }

        timeElapsed = Time.time - startTime;

        string minutes = ((int) timeElapsed / 60).ToString();
        string seconds = (timeElapsed % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    public void Finish()
    {
        finished = true;
    }

    public float getTimeElapsed()
    {
        return timeElapsed;
    }
}
