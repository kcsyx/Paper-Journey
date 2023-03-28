using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    //Array to store audio files
    public Sound[] bgmSounds, sfxSounds; 
    public AudioSource bgmSource, sfxSource;

    public static AudioManager instance;
    public static float sfxVol = 0.5f;
    public static float bgmVol = 0.2f;

    private void Awake()
    {
        //Instantiate AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGM("bgm");
    }

    public void PlayBGM(string name)
    {
        Sound s = Array.Find(bgmSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Audio Not Found");
        }

        else
        {
            bgmSource.clip = s.clip;
            bgmSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
       
        if (s == null)
        {
            Debug.Log("Audio Not Found");
        }

        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }

    public void BGMVolume(float volume)
    {
        bgmVol = volume;
        bgmSource.volume = bgmVol;
    }

    public void SFXVolume(float volume)
    {
        sfxVol = volume;
        sfxSource.volume = sfxVol;
    }
}
