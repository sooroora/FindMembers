using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;//UI������Ʈ ����Ϸ��� ����ϴ� using��

public class VolumeSlider : MonoBehaviour// ����� ���� ���� �����̴� ���� Ŭ����
{
    [SerializeField] Slider masterSlider;// ������ ������ �����ϴ� �����̴�
    [SerializeField] Slider fxSlider;// ȿ����(SFX) ������ �����ϴ� �����̴�
    [SerializeField] Slider bgmSlider; // �������(BGM) ������ �����ϴ� �����̴� (�ν����Ϳ� ���� �Ҵ� ����)

    void Start()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);// ������ �����̴� ���� �ٲ� �� SetMasterVolume ����
        fxSlider.onValueChanged.AddListener(SetFxVolume); // ȿ���� �����̴� ���� �ٲ� �� SetFxVolume ����
        bgmSlider.onValueChanged.AddListener(SetBgmVolume);// ������� �����̴� ���� �ٲ� �� SetBgmVolume ����

        masterSlider.value = 1f;// ������ ���� �⺻���� 1.0���� ���� (�ִ�)
        fxSlider.value = 0.5f;// ȿ���� ���� �⺻���� 0.5�� ����
        bgmSlider.value = 0.5f;// ������� ���� �⺻���� 0.5�� ����
    }


    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;// ��ü �����(������ ����)�� ����
    }

    public void SetFxVolume(float volume)
    {
        AudioManager.Instance.SetSfxVolume(volume);// AudioManager�� ���� ȿ���� ���� ����
    }
    

    public void SetBgmVolume(float volume)
    {
        AudioManager.Instance.SetBgmVolume(volume);// AudioManager�� ���� ������� ���� ����
    }

}
