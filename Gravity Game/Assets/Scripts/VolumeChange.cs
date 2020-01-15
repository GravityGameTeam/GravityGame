using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    private AudioSource[] audioSources;
    private int selectedTrack = 0;
    private float track;

    // Start is called before the first frame update
    
    void Start()
    {
        audioSources = GetComponents<AudioSource>(); //accesses both AudioSources - normal and rickroll
        
        //randomly chooses one AudioSource from the list to play, 1/100 chance of Rick Astley.
        track = Random.value * 100;
        if (track < 1 /*comment out conditional and replace with false to disable rickroll*/)
        {
            //AudioSource 0 is rickroll. Turns off other AudioSource and sets Astley volume to full.
            selectedTrack = 0;
            Mute();
            SetVol(1f);
        }
        else if (track < 80)
        {
            //other tracks are normal. Turns off Astley AudioSource and sets volume to half.
            selectedTrack = 1;
            Mute();
            SetVol(0.5f);
        }
        else if (track < 90)
        {
            selectedTrack = 2;
            Mute();
            SetVol(0.5f);
        }
        else
        {
            selectedTrack = 3;
            Mute();
            SetVol(0.5f);
        }
    }
    
    public void SetVol(float vol)
    {
        audioSources[selectedTrack].volume = vol;
    }

    private void Mute()
    {
        foreach (AudioSource source in audioSources)
        {
            source.volume = 0f;
        }
    }
}
