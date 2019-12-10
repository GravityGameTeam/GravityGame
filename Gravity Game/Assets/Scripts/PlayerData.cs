using System.Collections.Generic;

public class PlayerData
{
    static public int selectedLevel = 1;
    static public int farthestLevel = 1;
    static public readonly int numberOfLevels = 3;
    
    static public string skinPick = "";

    static public List<float> scores = new List<float>(numberOfLevels);
}
