using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public void AssignStars()
    {
        float[][] times;
        times = new float[20][];
        times[1] = new [] {1.2f,5,9};
        times[2] = new [] {2f,7.5f,12f};
        times[3] = new [] {4f,8f,16f};
        times[4] = new [] {5f,10,17};
        times[5] = new [] {2f,7.5f,12f};
        times[6] = new [] {4f,8f,16f};
        times[7] = new [] {2f,7.5f,12f};
        times[8] = new [] {4f,8f,16f};
        times[9] = new[] {4f, 7f, 15f};
        times[10] = new[] {4f, 7f, 15f};
        times[11] = new[] {4f, 7f, 15f};
        times[12] = new[] {15f, 45f, 90f};
        times[13] = new[] {15f, 45f, 90f};
        //times[4] = new [] {};

        if (PlayerData.time < times[PlayerData.selectedLevel][2])
        {
            star1.SetActive(true);
        }
        if (PlayerData.time < times[PlayerData.selectedLevel][1])
        {
            star2.SetActive(true);
        }
        if (PlayerData.time < times[PlayerData.selectedLevel][0])
        {
            star3.SetActive(true);
        }
        


    }


}
