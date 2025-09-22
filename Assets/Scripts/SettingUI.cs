using System.Collections;
using System.Collections.Generic;
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
    }
    
    
    // 채윤님 AudioManager 나오면  설정하는 내용 추가 필요
    public void SetMasterVolume(float volume)
    {
        
    }


    public void SetFxVolume(float volume)
    {
        
    }

    public void SetBgmVolume(float volume)
    {
        
    }
    
    
}
