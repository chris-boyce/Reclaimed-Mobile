using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    static public AudioSource[] AudioController;

    void Start()
    {
        AudioController = (AudioSource[])FindObjectsOfType(typeof(AudioSource));
    }
    static public void PlaySound(AudioClip Sound)
    {
        if (AudioController[0])
        {
            AudioController[0].volume = PlayerPrefs.GetFloat("SFXVolume");
            AudioController[0].PlayOneShot(Sound, PlayerPrefs.GetFloat("SFXVolume"));
        }
        
    }
    static public void PlayMusic(AudioClip Sound)
    {
        AudioController[1].volume = PlayerPrefs.GetFloat("MusicVolume");
        AudioController[1].PlayOneShot(Sound, PlayerPrefs.GetFloat("MusicVolume"));
    }
    static public void StopMusic()
    {
        AudioController[1].Stop();
    }
    static public void StopSound()
    {
        AudioController[0].Stop();
    }


    void OnLevelWasLoaded(int level)
    {
        AudioController[1].Stop();
    }
}
