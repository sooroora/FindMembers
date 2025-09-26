using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;//UI������Ʈ ����Ϸ��� ����ϴ� using��

public class VolumeSlider : MonoBehaviour// ����� ���� ���� �����̴� ���� Ŭ����
{
    [SerializeField] Slider masterSlider;// ������ ������ �����ϴ� �����̴�
    [SerializeField] Slider fxSlider;// ȿ����(SFX) ������ �����ϴ� �����̴�
    [SerializeField] Slider bgmSlider; // �������(BGM) ������ �����ϴ� �����̴� (�ν����Ϳ� ���� �Ҵ� ����)

    void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);// ������ �����̴� ���� �ٲ� �� SetMasterVolume ����
        fxSlider.onValueChanged.AddListener(SetFxVolume); // ȿ���� �����̴� ���� �ٲ� �� SetFxVolume ����
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);// ������� �����̴� ���� �ٲ� �� SetBgmVolume ����

       
        if(PlayerPrefs.HasKey("MasterVolume")==false)//�ִ��� ������ Ȯ��
        {
            PlayerPrefs.SetFloat("MasterVolume", 1f);
            PlayerPrefs.SetFloat("SetFxVolume", 0.5f);
            PlayerPrefs.SetFloat("SetBgmVolume", 0.5f);
        }

        masterSlider.value=PlayerPrefs.GetFloat("MasterVolume");//�������°�
        fxSlider.value = PlayerPrefs.GetFloat("SetFxVolume");// ȿ���� ���� �������ð� ��������
        bgmSlider.value = PlayerPrefs.GetFloat("SetBgmVolume");// ������� ���� �������ð� ��������

    }


    public void SetMasterVolume(float volume)
    {
        
        AudioListener.volume = volume;// ��ü �����(������ ����)�� ����

        PlayerPrefs.SetFloat("MasterVolume", volume);// ������ ������ �� ����

    }

    public void SetFxVolume(float volume)
    {
        AudioManager.Instance.SetSfxVolume(volume);// AudioManager�� ���� ȿ���� ���� ����

        PlayerPrefs.SetFloat("SetFxVolume", volume);// ������ ������ �� ����

    }
    

    public void SetBgmVolume(float volume)
    {
        AudioManager.Instance.SetBgmVolume(volume);// AudioManager�� ���� ������� ���� ����

        PlayerPrefs.SetFloat("SetBgmVolume", volume);// ������ ������ �� ����
    }
}
