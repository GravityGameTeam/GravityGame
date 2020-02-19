using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public Player playerScript;
    public GameObject menuPanel;
    public GameObject timerManager;
    public GameObject player;
    public GameObject scoringManager;

    // Start is called before the first frame update
    public void Start()
    {
        menuPanel.SetActive(false); //hides end level screen
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
        if (node.gameObject.CompareTag("EndPortal")) //if you reach the end, reset countdown, make player disappear, and beat level
        {
            Time.timeScale = 0f;
            player.SetActive(false);
            LevelBeat();
        }
    }

    public void LevelBeat() //on success
    {
        //Logs the timer score, accessing timer
        PlayerData.scores[PlayerData.selectedLevel - 1] = timerManager.GetComponent<Timer>().getTimeElapsed();
        Debug.Log("Player's score: " + PlayerData.scores[PlayerData.selectedLevel - 1]);
        
        //stores high scores
        if (PlayerData.scores[PlayerData.selectedLevel - 1] < PlayerData.highScores[PlayerData.selectedLevel - 1])
        {
            Debug.Log("New high score!");
            PlayerData.highScores[PlayerData.selectedLevel - 1] = PlayerData.scores[PlayerData.selectedLevel - 1];
        }
        
        //shows end level screen
        
        menuPanel.SetActive(true);
        scoringManager.GetComponent<Scoring>().AssignStars();
        //playerScript.Save();
        
        //if a new level was beaten, unlock the next one
        if (PlayerData.selectedLevel + 1 > PlayerData.farthestLevel)
        {
            PlayerData.farthestLevel ++;
        }


    }

    public void Restart() //reloads Game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit() //loads Menu
    {
        PlayerData.hasUserOpenedGameScene = true;
        PlayerData.loadStartScreen = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        
    }
}
