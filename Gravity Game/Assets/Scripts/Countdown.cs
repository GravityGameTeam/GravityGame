using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public GameObject countdown;
    public GameObject remoteGravityReset;
    public GameObject pauseButton;
    public GameObject quitManager;

    // Start is called before the first frame update
    public void Start()
    {
        beginCo();
    }

    public void beginCo()
    {
        StartCoroutine("StartDelay");
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }
        countdown.gameObject.SetActive(false);
        Time.timeScale = 1;

        remoteGravityReset.GetComponent<PlayerMovement>().ResetGravity(); //this remotely switches gravity to down
        pauseButton.SetActive(true); //shows hidden pause button when countdown ends

        if (PlayerData.selectedLevel > PlayerData.numberOfLevels) //if you've reached the final victory level
        {
            quitManager.GetComponent<EndLevel>().Quit(); //sends you back to title screen.
        }
    }

}

