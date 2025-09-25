using UnityEngine;

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
            Destroy(gameObject);//오디오매니저 싱글톤 만들어서 씬 넘어가도 오디오매니저 파괴 안되게 만들기, 오디오매니저를 만들어서 다른 곳에서 효과음 나올 타이밍에 함수만 갖다쓰면 바로 호출되게 만들기
        }
        if (PlayerPrefs.HasKey("MasterVolume") == false)//있는지 없는지 확인
        {
            PlayerPrefs.SetFloat("MasterVolume", 1f);
            PlayerPrefs.SetFloat("SetFxVolume", 0.5f);
            PlayerPrefs.SetFloat("SetBgmVolume", 0.5f);
        }
    }
    public AudioSource BGM;
    public AudioSource CardFlip;
    public AudioSource Matched;
    public AudioSource ClookTicking;
    public AudioSource Failed;
    public AudioSource clear;
    public AudioSource TimeOver;
    public AudioSource[] BtnClick;
    //오디오 소스 선언, 클릭버튼 사운드가 4가지가 랜덤으로 들어가는 식이라 배열을 통해 선언함, 인스펙터창에서 4칸 추가해서 사운드 추가

    public void PlayOneShot(string sfxname)//다른 스크립트에서 해당하는 사운드 이름을 문자열형식으로 넣어두면 바로 불러올 수 있게 함수를 작성함
    {
        switch (sfxname)
        {
            case "CardFlip":
                CardFlip.PlayOneShot(CardFlip.clip);// 카드 뒤집기 효과음
                break; //케이스 안에 있는 내용만 실행하고 종료

            case "Matched":
                Matched.PlayOneShot(Matched.clip);// 카드 짝 맞췄을 때 효과음
                break;
            
            case "ClookTicking":
                Failed.PlayOneShot(ClookTicking.clip);// 시계 초침 소리 
                break;

            case "Failed":
                Failed.PlayOneShot(Failed.clip);// 실패 효과음
                break;

            case "clear":
                Failed.PlayOneShot(clear.clip);// 클리어 효과음
                break;

            case "TimeOver":
                Failed.PlayOneShot(TimeOver.clip);// 제한 시간 종료 효과음
                break;
        }
    }

    public void PlayBGM()//브금 틀어주는 함수
    {
        BGM.loop = true; // 배경음악을 반복 재생하도록 설정
        BGM.Play();// 배경음악 재생 시작
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

   

    private void Start()
    {
        PlayBGM();// 게임 시작 시 자동으로 배경음악 재생
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;  //전체소리조절하는데 AudioListener 활용
    }

    public void SetBgmVolume(float volume)
    {
        BGM.volume = volume;    //나머지 소리는 오디오소스에서 변경 브금 볼륨
    }

    public void SetSfxVolume(float volume)//효과음 볼륨크기를 조절하는 함수, 이 안에다가 효과음들 다 집어넣어서 통일시키기
    {
        CardFlip.volume = volume;
        Matched.volume = volume;
        ClookTicking.volume = volume * 0.05f; //사운드가 얘만 커서 소리크기 임의조정
        Failed.volume = volume;
        clear.volume = volume;
        TimeOver.volume = volume;
        foreach (AudioSource click in BtnClick)//BtnClick 안에 있는 오디오소스 클릭 사운드들을 모두 순서대로 반복 실행
        {
            click.volume = volume;//BtnClick 사운드 4가지 볼륨은 변수 volume값을 가짐
        }
    }
}

