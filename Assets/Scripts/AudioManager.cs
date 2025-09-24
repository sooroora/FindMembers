using UnityEngine;

//public enum AudioType {BGM,CardFlip,Matched}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource BGM;
    public AudioSource CardFlip;
    public AudioSource Matched;
    public AudioSource ClookTicking;
    public AudioSource Failed;
    public AudioSource clear;
    public AudioSource TimeOver;
    public AudioSource[] BtnClick;

    public void PlayOneShot(string sfxname)
    {
        switch (sfxname)
        {
            case "CardFlip":
                CardFlip.PlayOneShot(CardFlip.clip);
                break;

            case "Matched":
                Matched.PlayOneShot(Matched.clip);
                break;
            
            case "ClookTicking":
                Failed.PlayOneShot(ClookTicking.clip);
                break;

            case "Failed":
                Failed.PlayOneShot(Failed.clip);
                break;

            case "clear":
                Failed.PlayOneShot(clear.clip);
                break;

            case "TimeOver":
                Failed.PlayOneShot(TimeOver.clip);
                break;
        }
    }

    public void PlayBGM()
    {
        BGM.loop = true;
        BGM.Play();
    }

    public void PlayRandomClick()
    {
        int randomclick = Random.Range(0, 4);
        BtnClick[randomclick].PlayOneShot(BtnClick[randomclick].clip);
    }

    public void UpdateBgmPitch()
    {
        BGM.pitch = 1.25f;
    }

    public void ResetBgmPitch()
    {
        BGM.pitch = 1f;
    }

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
        PlayBGM();
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;  //전체소리조절
    }

    public void SetBgmVolume(float volume)
    {
        BGM.volume = volume;    //나머지 소리는 오디오소스에서 변경
    }

    public void SetSfxVolume(float volume)
    {
        CardFlip.volume = volume;
        Matched.volume = volume;
        ClookTicking.volume = volume * 0.05f;
        Failed.volume = volume;
        clear.volume = volume;
        TimeOver.volume = volume;
        //BtnClick[0,1,2,3].volume = volume; 
    }
}

