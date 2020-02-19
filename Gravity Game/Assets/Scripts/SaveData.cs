using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SaveData 
{
    public int[] saveStarsLevels3;
    public int levelSave;
    public SaveData(Player player)
    {
        saveStarsLevels3 = Player.SaveStarslevels;
        levelSave = Player.FarthestLevel2;
        
    }
}
