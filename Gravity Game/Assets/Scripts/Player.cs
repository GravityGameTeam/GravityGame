using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int[] SaveStarslevels = Scoring.starsPerLevel;
    public static int FarthestLevel2 = PlayerData.farthestLevel;


    
    public void Save ()
    {
        Debug.Log(PlayerData.hasUserOpenedGameScene);
        if (PlayerData.hasUserOpenedGameScene)
        {
            SaveSystem.SavePlayer(this);
            
            SaveStarslevels = Scoring.starsPerLevel;
            FarthestLevel2 = PlayerData.farthestLevel;
            
            Debug.Log("This is a test save has saved farthest level " + FarthestLevel2);
        }
        
    }

    public void Load()
    {
        SaveData data = SaveSystem.LoadPlayer();

        PlayerData.farthestLevel = data.levelSave;
        Scoring.starsPerLevel = data.saveStarsLevels3;
        
        Debug.Log("This is a test load has saved farthest level " + PlayerData.farthestLevel);
        PlayerData.loadStartScreen = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
