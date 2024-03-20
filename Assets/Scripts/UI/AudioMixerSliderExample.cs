using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Runtime.CompilerServices;

public class AudioMixerSliderExample : MonoBehaviour
{

    private const float DisabledVolume = -80;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private float _minVolume;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("_musicVolume"))
        {
            _volumeSlider.value = PlayerPrefs.GetFloat("_musicVolume");
        }
        else
        {
            _volumeSlider.value = 1f;
        }
        _volumeSlider.SetValueWithoutNotify(GetMixerValume());
    }

    // Update is called once per frame
    public void UpdateMixerVolume(float volumeValue) //обновление громкости
    {
        SetMixerVolume(volumeValue);
    }

    private void SetMixerVolume(float volumeValue)
    {
        float mixerVolume;
        if (volumeValue == 0) { 
        mixerVolume = DisabledVolume;}
        else
        {
            mixerVolume = Mathf.Lerp(_minVolume,1,volumeValue);
        }
        _audioMixer.SetFloat("_musicVolume", mixerVolume);
        PlayerPrefs.SetFloat("_musicVolume",_volumeSlider.value);
    }

    private float GetMixerValume()
    {
        _audioMixer.GetFloat("_musicVolume", out float mixerVolume);
        if (mixerVolume == DisabledVolume) { return 0; }
        else
        {
            return Mathf.Lerp(1, 0, mixerVolume / _minVolume);
        }
    }

}
