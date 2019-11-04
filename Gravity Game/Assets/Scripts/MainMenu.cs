using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public List<GameObject> levelPrefabs =  new List<GameObject>();
    
    public void Level1Button ()
    {
        SceneManager.LoadScene("Game");
        //GetComponent<EndLevel>().SwitchLevel(1);
    }
}
