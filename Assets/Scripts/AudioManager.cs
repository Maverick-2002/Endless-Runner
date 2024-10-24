using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        PlayMusic(SoundEnum.SoundTrack);
    }


    public void PlayMusic(SoundEnum soundName)
    {
        Sound sounds = Array.Find(musicSounds, x => x.soundName == soundName);

        if (sounds == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = sounds.sound;
            musicSource.Play();
        }
    }
    public void StopMusic(SoundEnum soundName)
    {
        Sound sounds = Array.Find(musicSounds, x => x.soundName == soundName);

        if (sounds == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = sounds.sound;
            musicSource.Stop();
        }

    }
    public void PlaySFX(SoundEnum soundName)
    {
        Sound sounds = Array.Find(sfxSounds, x => x.soundName == soundName);

        if (sounds == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(sounds.sound);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}