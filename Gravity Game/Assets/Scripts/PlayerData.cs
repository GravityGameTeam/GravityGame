using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    static public int selectedLevel = 1;
    static public int farthestLevel = 1;
    static public readonly int numberOfLevels = 3;
    
    static public string skinPick = "";
    
    static public Vector2 spawnPoint = new Vector2(0f, 0f);

    static public List<float> scores = new List<float> {0f, 0f, 0f};
    static public List<float> highScores = new List<float> {1000000f, 1000000f, 1000000f};

    static private List<float> allTimeRecords = new List<float> {0.81f, 1.11f, 3.02f};
}
