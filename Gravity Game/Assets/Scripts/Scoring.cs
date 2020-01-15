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
        times[1] = new float[] {1.2f,5,9};
        times[2] = new float[] {2f,7.5f,12f};
        times[3] = new float[] {};

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
