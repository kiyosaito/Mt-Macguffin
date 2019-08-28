﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region References/Variables
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resDropdown;
    private Resolution[] res;
    #endregion

    private void Start()
    {
        res = Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> resOptions = new List<string>();

        int curResIndex = 0;


        for (int i = 0; i < res.Length; i++)
        {
            string option = res[i].width + "x" + res[i].height;
            resOptions.Add(option);
            if (res[i].width==Screen.currentResolution.width&& res[i].height == Screen.currentResolution.height)
            {
                curResIndex = i;
            }
        }
        resDropdown.AddOptions(resOptions);
        resDropdown.value = curResIndex;
        resDropdown.RefreshShownValue();

    }

    #region Options Menu
    public void OptionsMenuSetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void OptionsMenuSetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void OptionsMenuFullScreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void OptionsMenuSetResolution(int resIndex)
    {
        Resolution resolution  = res[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    #endregion

    #region Main Menu
    public void MainMenuePlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuQuit()
    {
        Application.Quit();
    }
    #endregion
}
