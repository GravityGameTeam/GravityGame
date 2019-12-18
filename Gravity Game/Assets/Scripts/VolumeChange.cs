using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    private AudioSource[] audioSource;
    private int selectedTrack = 0;

    // Start is called before the first frame update
    
    void Start()
    {
        audioSource = GetComponents<AudioSource>();
        
        if (Mathf.RoundToInt(Random.value * 100) == 1 /*comment out conditional and replace with false to disable rickroll*/)
        {
            selectedTrack = 1;
            audioSource[0].volume = 0f;
            audioSource[1].volume = 1f;
        }
        else
        {
            audioSource[0].volume = 0.5f;
            audioSource[1].volume = 0f;
        }
    }
    
    public void SetVol(float vol)
    {
        //prevents changing volume with rickroll
        if (selectedTrack == 0)
        {
            audioSource[0].volume = vol;
        }
    }
}
