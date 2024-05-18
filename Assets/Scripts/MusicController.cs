using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;
using Unity.VisualScripting;

public class MusicController : MonoBehaviour
{
    public List<AudioClip> musicTracks;
    private AudioSource audioSource;

    private bool musicPlaying;
    private int musicIndex;

    private bool transitioning;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();       
        musicPlaying = true;
        musicIndex = 0;
        transitioning = false;
    }

    void Update()
    {
        if (!audioSource.isPlaying && musicPlaying && !transitioning)
        {
            StartCoroutine(TransitionToNextTrack());
        }
    }

    private IEnumerator TransitionToNextTrack()
    {
        transitioning = true;

        if (musicIndex == musicTracks.Count - 1)
        {
            musicIndex = 0;
        }
        else
        {
            musicIndex++;
        }

        yield return StartCoroutine(PlayTrack(musicTracks[musicIndex]));
        transitioning = false;
    }

    public void Stop()
    {
        musicPlaying = false;
        StartCoroutine(FadeOutMusic());
    }

    private IEnumerator FadeOutMusic()
    {
        float fadeDuration = 1.0f;
        float startvolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startvolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
    }


    public IEnumerator PlayTrack(AudioClip clip)
    {
        
        float fadeDuration = 1.0f;
        float targetVolume = 1.0f;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= targetVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();

        audioSource.clip = clip;

        audioSource.Play();
        audioSource.volume = 0;

        while (audioSource.volume < targetVolume)
        {
            audioSource.volume += targetVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.volume = 1f;
    }

    

}
