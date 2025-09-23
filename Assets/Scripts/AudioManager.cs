using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


//public enum AudioType {BGM,CardFlip,Matched}


public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

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

    public AudioSource BGM;
    public AudioSource CardFlip;
    public AudioSource Matched;


    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;


    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;//��ü�Ҹ�����

    }

    public void SetBgmVolume(float volume)
    {
        BGM.volume = volume;//������ �Ҹ��� ������ҽ����� ����
    }

    public void SetSfxVolume(float volume)
    {
        CardFlip.volume = volume;
        Matched.volume = volume;
        Debug.Log(volume);
    }
}

