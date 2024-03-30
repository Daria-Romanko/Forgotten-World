using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;

public class music : MonoBehaviour
{
    public List<AudioClip> musicTracks;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextTrack();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }
    void PlayNextTrack()
    {
        if (musicTracks.Count > 0)
        {
            Random rd = new Random();
            int ind = rd.Next(0, musicTracks.Count);
            audioSource.clip = musicTracks[ind];
            audioSource.Play();
        }
    }
}
