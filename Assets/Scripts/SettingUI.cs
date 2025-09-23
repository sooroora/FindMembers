using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider fxSlider;
    [SerializeField] Slider bgmSlider;

   

    void Start()
    {

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        fxSlider.onValueChanged.AddListener(SetFxVolume);
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);

        masterSlider.value = 0.5f;
        fxSlider.value = 0.5f;
        bgmSlider.value = 0.5f;
    }

    


    // 채윤님 AudioManager 나오면  설정하는 내용 추가 필요
    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        AudioListener.volume = volume;
    }


    public void SetFxVolume(float volume)
    {
        AudioManager.Instance.SetSfxVolume(volume);
    }

    public void SetBgmVolume(float volume)
    {
        AudioManager.Instance.SetBgmVolume(volume);
    }
    
    
}
