using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseMenu;
    public GameObject PauseButton;

    private void Start()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(false); //hides the button by default, it appears when countdown ends
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
