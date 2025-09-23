using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    
    public void SetMasterVolume(float volume)
    {
        AudioManager.Instance.SetMasterVolume(volume);  
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
