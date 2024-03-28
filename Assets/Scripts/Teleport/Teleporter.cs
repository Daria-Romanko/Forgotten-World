using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform dest;
    [SerializeField]
    public CinemachineVirtualCamera camera1;
    [SerializeField]
    public CinemachineVirtualCamera camera2;
    [SerializeField]
    public string locationName;
    [SerializeField]
    public AudioClip audioClip;
    [SerializeField]
    public AudioSource audioSource;

    public Transform GetTransform() { return dest; }

    public void PlayAudioClip()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (audioClip != null && audioSource != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
