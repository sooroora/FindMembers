using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioMixer mixer;
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    private float masterVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        float bgmVol = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);

        SetBGMVolume(bgmVol);
        SetSFXVolume(sfxVol);
    }

    public void SetBGMVolume(float value)
    {
        bgmSource.volume = value * masterVolume;
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value * masterVolume;
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void SetMasterVolume(float value)
    {
        masterVolume = value;
        bgmSource.volume = PlayerPrefs.GetFloat("BGMVolume", 0.5f) * masterVolume;
        sfxSource.volume = PlayerPrefs.GetFloat("SFXVolume", 0.5f) * masterVolume;
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, sfxSource.volume);
    }
}

