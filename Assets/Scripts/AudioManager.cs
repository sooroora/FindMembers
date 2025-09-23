using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


//public enum AudioType {BGM,CardFlip,Matched}


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource BGM;
    public AudioSource CardFlip;
    public AudioSource Matched;
  

    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;


    private float masterVolume = 0.5f;
    private float bgmVolume = 0.5f;
    private float sfxVolume = 0.5f;


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



    public void SetMasterVolume(float volume)
    {
        AudioListener.volume=volume;//��ü�Ҹ�����
            
    }

    public void SetBgmVolume(float volume)
    {
        BGM.volume = volume;//������ �Ҹ��� ������ҽ����� ����
    }

    public void SetSfxVolume(float volume)
    {
        CardFlip.volume = volume;
        Matched.volume = volume;
    }
}

