using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;//UI컴포넌트 사용하려면 써야하는 using문

public class VolumeSlider : MonoBehaviour// 오디오 볼륨 조절 슬라이더 관리 클래스
{
    [SerializeField] Slider masterSlider;// 마스터 볼륨을 조절하는 슬라이더
    [SerializeField] Slider fxSlider;// 효과음(SFX) 볼륨을 조절하는 슬라이더
    [SerializeField] Slider bgmSlider; // 배경음악(BGM) 볼륨을 조절하는 슬라이더 (인스펙터에 직접 할당 가능)

    void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);// 마스터 슬라이더 값이 바뀔 때 SetMasterVolume 실행
        fxSlider.onValueChanged.AddListener(SetFxVolume); // 효과음 슬라이더 값이 바뀔 때 SetFxVolume 실행
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);// 배경음악 슬라이더 값이 바뀔 때 SetBgmVolume 실행

       
        if(PlayerPrefs.HasKey("MasterVolume")==false)//있는지 없는지 확인
        {
            PlayerPrefs.SetFloat("MasterVolume", 1f);
            PlayerPrefs.SetFloat("SetFxVolume", 0.5f);
            PlayerPrefs.SetFloat("SetBgmVolume", 0.5f);
        }

        masterSlider.value=PlayerPrefs.GetFloat("MasterVolume");//가져오는거
        fxSlider.value = PlayerPrefs.GetFloat("SetFxVolume");// 효과음 볼륨 유저세팅값 가져오기
        bgmSlider.value = PlayerPrefs.GetFloat("SetBgmVolume");// 배경음악 볼륨 유저세팅값 가져오기

    }


    public void SetMasterVolume(float volume)
    {
        
        AudioListener.volume = volume;// 전체 오디오(마스터 볼륨)를 조절

        PlayerPrefs.SetFloat("MasterVolume", volume);// 유저가 변경한 값 저장

    }

    public void SetFxVolume(float volume)
    {
        AudioManager.Instance.SetSfxVolume(volume);// AudioManager를 통해 효과음 볼륨 조절

        PlayerPrefs.SetFloat("SetFxVolume", volume);// 유저가 변경한 값 저장

    }
    

    public void SetBgmVolume(float volume)
    {
        AudioManager.Instance.SetBgmVolume(volume);// AudioManager를 통해 배경음악 볼륨 조절

        PlayerPrefs.SetFloat("SetBgmVolume", volume);// 유저가 변경한 값 저장
    }
}
