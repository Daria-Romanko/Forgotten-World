using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer _mixer;
    void Start()
    {
        if (PlayerPrefs.HasKey("_musicVolume"))
        {
            _mixer.SetFloat("_musicVolume", Mathf.Lerp(-80, 0, PlayerPrefs.GetFloat("_musicVolume")));
        }

    }
}

