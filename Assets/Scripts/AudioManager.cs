using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.UxmlAttributeDescription;


//public enum AudioType {BGM,CardFlip,Matched}


public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public AudioSource BGM;
    public AudioSource CardFlip;
    public AudioSource Matched;

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

        
        BGM.volume = 0.5f;
        CardFlip.volume = 0.5f;
        Matched.volume = 0.5f;
    }
        

  


    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;//��ü�Ҹ�����
    }

    public void SetBgmVolume(float volume)
    {
        BGM.volume = 0.5f;
        BGM.volume = volume;//������ �Ҹ��� ������ҽ����� ����
    }

    public void SetSfxVolume(float volume)
    {
        CardFlip.volume = 0.5f;
        Matched.volume = 0.5f;

        CardFlip.volume = volume;
        Matched.volume = volume;
        Debug.Log(volume);
    }

    


}

