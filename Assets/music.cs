using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public List<AudioClip> musicTracks;
    private AudioSource audioSource;
    private int currentTrackIndex = 0;
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
            audioSource.clip = musicTracks[currentTrackIndex];
            audioSource.Play();
            currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Count;
        }
    }
}
