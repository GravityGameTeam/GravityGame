using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    private AudioSource[] audioSources;
    private int track = 0;

    // Start is called before the first frame update
    
    void Start()
    {
        audioSources = GetComponents<AudioSource>(); //accesses all AudioSources
        SetTrack(track);
        SetVol(0.5f);
    }

    void Update()
    {
        if (PlayerData.musicTrack != track) //If currently loaded track is different than what is set in PlayerData
        {
            track = PlayerData.musicTrack; //update track
            SetTrack(track);
        } //otherwise, keep playing as normal
    }
    
    public void SetVol(float vol)
    {
        foreach (AudioSource source in audioSources)
        {
            source.volume = vol;
        }
    }

    private void Mute()
    {
        Debug.Log("Deactivating music");
        foreach (AudioSource source in audioSources)
        {
            source.enabled = false;
            Debug.Log("Deactivated track");
        }
    }

    public void SetTrack(int track)
    {
        Mute();

        audioSources[track].enabled = true;
    }
}
