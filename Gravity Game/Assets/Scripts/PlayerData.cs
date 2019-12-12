using System.Collections.Generic;

public class PlayerData
{
    static public int selectedLevel = 1;
    static public int farthestLevel = 1;
    static public readonly int numberOfLevels = 3;
    
    static public string skinPick = "";

    static public List<float> scores = new List<float> {0f, 0f, 0f};
    static public List<float> highScores = new List<float> {1000000f, 1000000f, 1000000f};

    static private List<float> allTimeRecords = new List<float> {0.83f, 1000000f, 1000000f};
}
