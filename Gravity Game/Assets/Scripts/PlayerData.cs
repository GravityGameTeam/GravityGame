using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData //a static class that stores all data held between scenes
{
    static public int selectedLevel = 1; //stores level to be loaded on Game Start
    static public int farthestLevel = 1; //controls locked levels
    static public readonly int numberOfLevels = 9;

    static public bool loadStartScreen = true;
    
    static public string skinPick = ""; //assigned by skin picker
    
    static public Vector2 spawnPoint = new Vector2(0f, 0f); //changed based on level

    static public float time = 0;

    static public int[] saveData = new int[2];

    public static int TotalStars = Scoring.Sum();
    
    static public List<float> scores = new List<float>

    {
        0f, //1
        0f, 
        0f, 
        0f, 
        0f, //5
        0f, 
        0f,
        0f,
        0f,
        0f, //10
        0f,
        0f,
        0f,
    };
    static public List<float> highScores = new List<float>
    {
        1000000f, //1
        1000000f, 
        1000000f, 
        1000000f, 
        1000000f, //5
        1000000f, 
        1000000f,
        1000000f,
        1000000f,
        1000000f, //10
        1000000f,
        1000000f,
        1000000f,
    };

    static private readonly List<float> allTimeRecords = new List<float>
    {
        0.81f, //1
        1.11f, 
        3.01f, 
        2.90f,
        1.85f, //5
        1000000f, 
        1000000f,
        4f,
        1000000f,
        1000000f, //10
        1000000f,
        12.8f,
        1000000f,
    };
}
