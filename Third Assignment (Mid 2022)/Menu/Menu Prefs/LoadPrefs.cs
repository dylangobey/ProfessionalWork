using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
    [Header("General Setting")] // Creates a header in Unity Editor called "General Settings"
    [SerializeField] private bool canUse = false; // Creates a private bool called "canUse" and is defaulted to false
    [SerializeField] private MainMenu menuController; // Creates a private link to MainMenu and is refrenced as "menuController"

    [Header("Volume Setting")] // Creates a header in Unity Editor called "Volume Setting"
    [SerializeField] private TMP_Text volumeTextValue = null; // Creates a TMP_Text refrenced as "volumeTextValue" and is defaulted as null
    [SerializeField] private Slider volumeSlider = null; // Creates a private slider refrenced as "volumeSlider" and is defaulted as null
     
    [Header("Brightness Setting")] // Creates a header in Unity Editor called "Brightness Setting"
    [SerializeField] private Slider brightnessSlider = null; // Creates a slider refrenced as "brightnessSlider" and is defaulted as null
    [SerializeField] private TMP_Text brightnessTextValue = null; // Creates a TMP_Text refrenced as "brightnessTextValue" and is defaulted as null

    [Header("Quality Level Setting")] // Creates a header in Unity Editor called "Quality Level Setting"
    [SerializeField] private TMP_Dropdown qualityDropdown; // Creates a TMP_Dropdown refrenced as "qualityDropdown" 

    [Header("Fullscreen Setting")] // Creates a header in Unity Editor called "Fullscreen Setting"
    [SerializeField] private Toggle fullScreenToggle; // Creates a Toggle refrenced as "fullScreenToggle"

    [Header("Sensitivity Setting")] // Creates a header in Unity Editor called "Sensitivity Setting"
    [SerializeField] private TMP_Text controllerSenTextValue = null; // Creates a TMP_Text refrenced as "controllerSenTextValue" and is defaulted as null
    [SerializeField] private Slider controllerSenSlider = null; // Creates a Slider refrenced as "controllerSenSlider" and is defaulted as null

    [Header("Invert Y Setting")] // Creates a header in Unity Editor called "Invert Y Setting"
    [SerializeField] private Toggle invertYToggle = null; // Creates a Toggle refrenced as "invertYToggle" and is defaulted as null

    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                menuController.ResetButton("Audio");
            }

            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);
            }

            if (PlayerPrefs.HasKey("masterFullscreen"))
            {
                int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");

                if(localFullscreen == 1)
                {
                    Screen.fullScreen = true;
                    fullScreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullScreenToggle.isOn = false;
                }
            }

            if (PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                brightnessTextValue.text = localBrightness.ToString("0.0");
                brightnessSlider.value = localBrightness;
            }

            if (PlayerPrefs.HasKey("masterSen"))
            {
                float localSensitivity = PlayerPrefs.GetFloat("masterSen");

                controllerSenTextValue.text = localSensitivity.ToString("0");
                controllerSenSlider.value = localSensitivity;
                menuController.mainControllerSen = Mathf.RoundToInt(localSensitivity);
            }

            if (PlayerPrefs.HasKey("masterInvertY"))
            {
                if(PlayerPrefs.GetInt("masterInvertY") == 1)
                {
                    invertYToggle.isOn = true;
                }

                else
                {
                    invertYToggle.isOn = false;
                }
            }
        }
    }
}
