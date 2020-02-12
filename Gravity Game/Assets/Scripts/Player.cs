using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int[] SaveStarslevels = Scoring.starsPerLevel;
    public static int FarthestLevel2 = PlayerData.farthestLevel;

    public void Start()
    {
        SaveStarslevels = Scoring.starsPerLevel;
        FarthestLevel2 = PlayerData.farthestLevel;
        
        SaveData data = SaveSystem.LoadPlayer();

        PlayerData.farthestLevel = data.levelSave;
        Scoring.starsPerLevel = data.saveStarslevels3;
        
        Debug.Log("yefgjhfrv" + PlayerData.farthestLevel);

    }
    
    public void Save ()
    {
        SaveSystem.SavePlayer(this);
        
        Debug.Log("yefgjhfrvdkfshnjdnbj");

    }

    public void Load()
    {

    }
    
}
