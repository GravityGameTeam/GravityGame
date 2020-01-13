using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData //a static class that stores all data held between scenes
{
    static public int selectedLevel = 1; //stores level to be loaded on Game Start
    static public int farthestLevel = 1; //controls locked levels
    static public readonly int numberOfLevels = 7;

    static public bool loadStartScreen = true;
    
    static public string skinPick = ""; //assigned by skin picker
    
    static public Vector2 spawnPoint = new Vector2(0f, 0f); //changed based on level

    static public List<float> scores = new List<float>
    {
        0f, 
        0f, 
        0f, 
        0f, 
        0f, 
        0f, 
        0f
    };
    static public List<float> highScores = new List<float>
    {
        1000000f, 
        1000000f, 
        1000000f, 
        1000000f, 
        1000000f, 
        1000000f, 
        1000000f
    };

    static private readonly List<float> allTimeRecords = new List<float>
    {
        0.81f, 
        1.11f, 
        3.02f, 
        3.79f, 
        4.58f, 
        1000000f, 
        1000000f
    };
}
