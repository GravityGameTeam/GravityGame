using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public bool appear = true;
    
    public GameObject menuPanel;
    public GameObject timerManager;

    // Start is called before the first frame update
    public void Start()
    {
        gameObject.SetActive(appear);
        menuPanel.SetActive(false);
    }

    void Update()
    {
        //automatic level beat
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameObject.SetActive(appear);
            Time.timeScale = 0f;
            LevelBeat();
        }
    }

    public void OnTriggerEnter2D(Collider2D node)
    {
        Debug.Log("Collided");
        appear = false;
        if (node.gameObject.CompareTag("EndPortal"))
        {
            gameObject.SetActive(appear);
            Time.timeScale = 0f;
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
        SceneManager.LoadScene("Menu");
    }
}
