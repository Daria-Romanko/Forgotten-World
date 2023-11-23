using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class NewBehaviourScript : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0; // число текущего разрешения экрана

        for (int i = 0; i < resolutions.Length; i++) // автоматические отображались разрешение экрана и частота
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);

    }

    // переход в полноэкранный режим

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    // переключение разрешения экрана

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // переключение качества графики

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // выход

    public void ExitSettings()
    {
        SceneManager.LoadScene("Level");
    }

    // сохранение

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingsPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference", System.Convert.ToInt32(Screen.fullScreen));
    }

    // загрузка параметров настроек, которые сохранили

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingsPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingsPreference");
        else
            qualityDropdown.value = 3; // пунктов в меню в графике

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("FullScreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
        else
            Screen.fullScreen = true;
    }


}
