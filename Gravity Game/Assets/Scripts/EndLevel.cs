﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject timerManager;
    public GameObject player;

    // Start is called before the first frame update
    public void Start()
    {
        menuPanel.SetActive(false);
    }

    void Update()
    {
        //automatic level beat
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0f;
            player.SetActive(false);
            LevelBeat();
        }
    }

    public void OnTriggerEnter2D(Collider2D node)
    {
        if (node.gameObject.CompareTag("EndPortal"))
        {
            Time.timeScale = 0f;
            player.SetActive(false);
            LevelBeat();
        }
    }

    public void LevelBeat()
    {
        PlayerData.scores[PlayerData.selectedLevel - 1] = timerManager.GetComponent<Timer>().getTimeElapsed();
        Debug.Log(PlayerData.scores[PlayerData.selectedLevel - 1]);
        if (PlayerData.scores[PlayerData.selectedLevel - 1] < PlayerData.highScores[PlayerData.selectedLevel - 1])
        {
            Debug.Log("New high score!");
            PlayerData.highScores[PlayerData.selectedLevel - 1] = PlayerData.scores[PlayerData.selectedLevel - 1];
        }
        
        menuPanel.SetActive(true);
        if (PlayerData.selectedLevel + 1 > PlayerData.farthestLevel)
        {
            PlayerData.farthestLevel ++;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        PlayerData.loadStartScreen = false;
        SceneManager.LoadScene("Menu");
    }
}
