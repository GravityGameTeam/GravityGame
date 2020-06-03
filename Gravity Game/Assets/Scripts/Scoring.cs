using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    
    public static int[] starsPerLevel = new int[PlayerData.numberOfLevels + 1];
    
    public Animator compAnim;


    public void AssignStars()
    {
        float[][] times;
        times = new float[PlayerData.numberOfLevels + 1][];
        times[1] = new [] {1.5f, 3f, 5f};
        times[2] = new [] {2.5f, 5f, 9f};
        times[3] = new [] {2.75f, 3.5f, 4f};
        times[4] = new [] {3.5f, 5f, 7f};
        times[5] = new [] {3.75f, 5f, 10f};
        times[6] = new [] {2.75f, 3f, 4f};
        times[7] = new [] {2.75f, 3f, 4f};
        times[8] = new [] {9f, 13f, 17f};
        times[9] = new [] {6.5f, 9f, 13f};
        times[10] = new[] {5.25f, 8f, 12f};
        times[11] = new[] {1f, 7f, 12f};
        times[12] = new[] {3f, 5.5f, 7f};
        times[13] = new[] {2.1f, 3.25f, 7f};
        times[14] = new[] {3.5f, 5.5f, 11f};
        times[15] = new[] {6f, 10f, 17f};
        times[16] = new[] {5f, 10f, 20f};
        times[17] = new[] {2.25f, 5.25f, 15};
        times[18] = new[] {5f, 7.5f, 10f};
        times[19] = new[] {7.75f, 10f, 15f};
        times[20] = new[] {6f, 8f, 13f};
        times[21] = new[] {1.25f, 1.75f, 3f};
        times[22] = new[] {2.1f, 2.5f, 3f};
        times[23] = new[] {1.5f, 3f, 5f};
        times[24] = new[] {6.1f, 6.25f, 6.5f};
        times[25] = new[] {7.25f, 10f, 15f};
        times[26] = new[] {7f, 10f, 15f};
        times[27] = new[] {7.5f, 12f, 20f};
        times[28] = new[] {4f, 5.5f, 10f};
        times[29] = new[] {17f, 20f, 25f};
        times[30] = new[] {10f, 15f, 20f};

        //times[4] = new [] {};

        if (PlayerData.time < times[PlayerData.selectedLevel][2])
        {
            compAnim.SetTrigger("star11");
            //Debug.Log("THIS IS STAR 1 " + starsPerLevel[PlayerData.selectedLevel]);
            //Debug.Log("This is the time: " + PlayerData.time);
            if (starsPerLevel[PlayerData.selectedLevel] < 1)
            {
                starsPerLevel[PlayerData.selectedLevel] = 1;
                //Debug.Log("THIS IS STAR 1a " + starsPerLevel[PlayerData.selectedLevel]);
            }
        }
        if (PlayerData.time < times[PlayerData.selectedLevel][1])
        {
            compAnim.SetTrigger("star22");
            //Debug.Log("THIS IS STAR 2 " + starsPerLevel[PlayerData.selectedLevel]);
            if (starsPerLevel[PlayerData.selectedLevel] < 2)
            {
                starsPerLevel[PlayerData.selectedLevel] = 2;
                //Debug.Log("THIS IS STAR 2a " + starsPerLevel[PlayerData.selectedLevel]);
            }
        }
        if (PlayerData.time < times[PlayerData.selectedLevel][0])
        {
            compAnim.SetTrigger("star33");
            if (starsPerLevel[PlayerData.selectedLevel] < 3)
            {
                starsPerLevel[PlayerData.selectedLevel] = 3;
            }
        }
    }
    
    public static int Sum(int startIndex, int endIndex) 
    {

        // Iterate through all elements and  
        // add them to sum 
        int sum = 0;
        for (int i = startIndex; i <= endIndex; i++)
        {
            sum += starsPerLevel[i];
        }
        return sum;
    }
}
