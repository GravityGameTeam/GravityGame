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
        audioSource = GetComponents<AudioSource>(); //accesses both AudioSources - normal and rickroll
        
        //randomly chooses one AudioSource from the list to play, 1/100 chance of Rick Astley.
        if (Mathf.RoundToInt(Random.value * 100) == 1 /*comment out conditional and replace with false to disable rickroll*/)
        {
            //track 1 is rickroll. Turns off other AudioSource and sets Astley volume to full.
            selectedTrack = 1;
            audioSource[0].volume = 0f;
            audioSource[1].volume = 1f;
        }
        else
        {
            //track 0 is normal. Turns off Astley AudioSource and sets volume to half.
            audioSource[0].volume = 0.5f;
            audioSource[1].volume = 0f;
        }
    }
    
    public void SetVol(float vol)
    {
        //Volume can only be changed if it's track 0. If it's Astley, it permanently remains at full volume.
        if (selectedTrack == 0)
        {
            audioSource[0].volume = vol;
        }
    }
}
