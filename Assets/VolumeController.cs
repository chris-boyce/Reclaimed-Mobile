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
    public Slider SFXSlider;
    public Slider MusicSlider;
    public Toggle BloodToggle;

    public AudioClip Music;

    void Start()
    {
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume");
        SFXSlider.value = SFXVolume;
        MusicSlider.value = MusicVolume;
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


}
