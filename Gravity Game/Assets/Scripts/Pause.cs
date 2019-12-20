using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseMenu;

    private void Start()
    {
        PauseMenu.SetActive(false);
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
