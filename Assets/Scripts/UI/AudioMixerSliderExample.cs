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
    [SerializeField] private string _mixerParam;
    [SerializeField] private float _minVolume;


    // Start is called before the first frame update
    void Start()
    {
        _volumeSlider.SetValueWithoutNotify(GetMixerValume());
    }

    // Update is called once per frame
    public void UpdateMixerVolume(float volumeValue) //обновление громкости
    {
        SetMixerValume(volumeValue);
    }

    private void SetMixerValume(float volumeValue)
    {
        float mixerValume;
        if (volumeValue == 0) { 
        mixerValume = DisabledVolume;}
        else
        {
            mixerValume = Mathf.Lerp(_minVolume,0,volumeValue);
        }
        _audioMixer.SetFloat(_mixerParam, mixerValume);
    }

    private float GetMixerValume()
    {
        _audioMixer.GetFloat(_mixerParam, out float mixerValume);
        if (mixerValume == DisabledVolume) { return 0; }
        else
        {
            return Mathf.Lerp(1, 0, mixerValume / _minVolume);
        }
    }

}
