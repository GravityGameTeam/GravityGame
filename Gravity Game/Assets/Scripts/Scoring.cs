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
        times[1] = new [] {1.4f,5.5f,9f};
        times[2] = new [] {2.5f,7.5f,12f};
        times[3] = new [] {4f,8f,16f};
        times[4] = new [] {5f,10,17};
        times[5] = new [] {3f,7.5f,12f};
        times[6] = new [] {4f,8f,16f};
        times[7] = new [] {2f,7.5f,12f};
        times[8] = new [] {20f,35f,60f};
        times[9] = new [] {4f, 7f, 15f};
        times[10] = new[] {4f, 7f, 15f};
        times[11] = new[] {4f, 7f, 15f};
        times[12] = new[] {15f, 45f, 90f};
        times[13] = new[] {15f, 45f, 90f};
        times[14] = new[] {15f, 45f, 90f};
        times[15] = new[] {15f, 45f, 90f};
        times[16] = new[] {15f, 45f, 90f};
        times[17] = new[] {15f, 45f, 90f};
        times[18] = new[] {15f, 45f, 90f};
        times[19] = new[] {0f, 0f, 0f};
        times[20] = new[] {0f, 0f, 0f};
        times[21] = new[] {0f, 0f, 0f};
        times[22] = new[] {0f, 0f, 0f};
        times[23] = new[] {0f, 0f, 0f};
        times[24] = new[] {0f, 0f, 0f};
        times[25] = new[] {0f, 0f, 0f};
        times[26] = new[] {0f, 0f, 0f};
        times[27] = new[] {0f, 0f, 0f};
        times[28] = new[] {0f, 0f, 0f};
        times[29] = new[] {0f, 0f, 0f};
        times[30] = new[] {0f, 0f, 0f};

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
