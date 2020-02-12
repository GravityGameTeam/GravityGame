using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SaveData 
{
    public int[] saveStarslevels3;
    public int levelSave;
    public SaveData(Player player)
    {
        saveStarslevels3 = Player.SaveStarslevels;
        levelSave = Player.FarthestLevel2;
        
    }
}
