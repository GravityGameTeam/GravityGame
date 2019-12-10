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

    // Start is called before the first frame update
    public void Start()
    {
        gameObject.SetActive(appear);
        menuPanel.SetActive(false);
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
        menuPanel.SetActive(true);
        if (LevelNumber.selectedLevel + 1 > LevelNumber.farthestLevel)
        {
            LevelNumber.farthestLevel = LevelNumber.farthestLevel + 1;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
