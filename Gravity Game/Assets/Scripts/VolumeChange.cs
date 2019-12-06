﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    private AudioSource _audioSource;

    private float musicVolume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.volume = musicVolume;
    }

    public void SetVol(float vol)
    {
        musicVolume = vol;
    }
}
