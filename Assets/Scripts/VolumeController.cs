using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using Toggle = UnityEngine.UI.Toggle;

public class VolumeController : MonoBehaviour
{
    public float SFXVolume;
    public float MusicVolume;
    public bool BloodEnable;
    public bool HapticEnable;
    public Slider SFXSlider;
    public Slider MusicSlider;
    public Toggle BloodToggle;
    public Toggle HapticToggle;

    public AudioClip Music;

    void Start()
    {
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = SFXVolume;
        MusicSlider.value = MusicVolume;
        if (PlayerPrefs.GetInt("HapticEnable") == 0)
        {
            HapticEnable = false;
            HapticToggle.isOn = false;
        }
        else
        {
            HapticEnable = true;
            HapticToggle.isOn = true;
        }

        if (PlayerPrefs.GetInt("BloodEnable") == 0)
        {
            BloodEnable = false;
            BloodToggle.isOn = false;
        }
        else
        {
            BloodEnable = true;
            BloodToggle.isOn = true;
        }
        SFXSlider.onValueChanged.AddListener(delegate { SFXValueChangeCheck(); });
        MusicSlider.onValueChanged.AddListener(delegate { MusicValueChangeCheck(); });
        BloodToggle.onValueChanged.AddListener(delegate { BloodValueChangeCheck(); });
        HapticToggle.onValueChanged.AddListener(delegate { HapticValueChangeCheck(); });
    }
    public void SFXValueChangeCheck()
    {
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }
    public void MusicValueChangeCheck()
    {
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        SoundController.StopMusic();
        SoundController.PlayMusic(Music);
    }
    public void BloodValueChangeCheck()
    {
        if (BloodEnable == true)
        {
            BloodEnable = false;
            PlayerPrefs.SetInt("BloodEnable", 0);
        }
        else
        {
            BloodEnable = true;
            PlayerPrefs.SetInt("BloodEnable", 10);
        }
        
    }
    public void HapticValueChangeCheck()
    {
        if (HapticEnable == true)
        {
            HapticEnable = false;
            PlayerPrefs.SetInt("HapticEnable", 0);
        }
        else
        {
            HapticEnable = true;
            PlayerPrefs.SetInt("HapticEnable", 10);
        }

    }


}
