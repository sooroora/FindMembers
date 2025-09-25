using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// [GameManager]
/// 게임의 핵심 로직(상태, 시간, 매칭, 승패)을 관리하는 싱글턴 매니저입니다.
/// </summary>
[DefaultExecutionOrder(-100)] // [Unity 설정] 다른 모든 스크립트보다 먼저 Awake/Start를 실행하도록 보장 (안정적인 초기화)
public class GameManager : MonoBehaviour
{
    // [디자인 패턴: 싱글턴] 어디서든 접근 가능하도록 유일한 인스턴스를 유지합니다.
    public static GameManager Instance;

    // [인스펙터 연결 변수]
    [SerializeField] TextMeshProUGUI timeText; // 남은 시간을 표시할 UI 텍스트
    [SerializeField] GameObject success;      // 게임 승리 시 활성화할 UI 패널
    [SerializeField] GameObject fail;         // 게임 오버 시 활성화할 UI 패널

    // [게임 상태 변수]
    public Card firstCard;      // 첫 번째로 뒤집은 카드 참조
    public Card secondCard;     // 두 번째로 뒤집은 카드 참조
    public float cardCount;     // 현재 남은 카드 쌍의 개수 (0이 되면 승리)
    public int currentLevel;    // 현재 플레이 중인 난이도 (0: Easy, 1: Normal, 2: Hard)
    public bool isLock;         // 카드 입력 잠금 상태 (두 장 뒤집은 후 처리 중일 때 true)

    // [디자인 패턴: 옵저버 패턴] 게임 오버 시 다른 컴포넌트(예: Board)에 알리는 이벤트
    public Action OnAllCardsFlip;

    public bool isPlay;         // 게임 진행 중 상태 플래그
    public float time;          // 남은 시간 (초)

    private bool isClookTick;   // 10초 미만 진입 시 오디오 효과를 한 번만 실행하기 위한 플래그

    private float delay = 0.3f;

    private void Awake()
    {
        // 싱글턴 인스턴스 초기화 로직
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복 생성 방지
        }
    }

    private void Start()
    {
        // [데이터 로드] PlayerPrefs에서 저장된 난이도 값을 로드 (없으면 기본값 0)
        currentLevel = PlayerPrefs.GetInt("level", 0);

        time = 60f; // 초기 남은 시간을 60초로 설정
    }

    private void Update()
    {
        if (!isPlay)
            return;

        // 시간 카운트다운 및 UI 업데이트
        time -= Time.deltaTime;
        timeText.text = time.ToString("F2");

        // [오디오 연동] 시간이 10초 이하로 남았을 때 긴장감 조성
        if (time <= 10f && !isClookTick)
        {
            // BGM 피치를 높여 시간 압박감을 줍니다. (AudioManager 책임)
            AudioManager.Instance.UpdateBgmPitch();
            // 시계 초침 사운드를 재생합니다.
            AudioManager.Instance.PlayOneShot("ClookTicking");
            isClookTick = true; // 단 한 번만 실행되도록 플래그 설정
        }

        // 시간 초과 시 게임 오버
        if (time <= 0f)
        {
            GameOver();
        }
    }

    /// <summary>
    /// 두 번째 카드가 뒤집혔을 때 매칭 여부를 확인하고 처리합니다.
    /// </summary>
    public void Matched()
    {
        isLock = true; // 매칭 처리 중 추가 입력 잠금

        if (firstCard.idx == secondCard.idx)
        {
            // [매칭 성공] 0.3초 딜레이 후 사운드 재생 (애니메이션과 싱크 맞추기)
            StartCoroutine(DelayPlay(delay, () => AudioManager.Instance.PlayOneShot("Matched")));

            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
                GameVictory();
        }
        else
        {
            // [매칭 실패] 0.3초 딜레이 후 사운드 재생
            StartCoroutine(DelayPlay(delay, () => AudioManager.Instance.PlayOneShot("Failed")));

            firstCard.ClosedCard();
            secondCard.ClosedCard();
        }

        // 다음 카드 선택을 위해 참조 해제
        firstCard = null;
        secondCard = null;
    }

    /// <summary>
    /// 지정된 시간(delay) 후 특정 동작(action)을 실행하는 헬퍼 코루틴입니다.
    /// </summary>
    IEnumerator DelayPlay(float delay, UnityAction action)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }

    /// <summary>
    /// 카드 선택 잠금을 해제합니다. (DestroyCardRoutine/ClosedCardRoutine에서 호출됨)
    /// </summary>
    public void UnLock()
    {
        isLock = false;
    }

    /// <summary>
    /// 게임을 시작 상태로 전환합니다.
    /// </summary>
    public void GameStart()
    {
        isPlay = true;
    }

    private void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        // BGM 피치 원상 복구 및 게임 오버 사운드 재생
        AudioManager.Instance.ResetBgmPitch();
        AudioManager.Instance.PlayOneShot("TimeOver");

        isClookTick = false; // 플래그 초기화
        isPlay = false;      // 게임 중지
        time = 0f;           // UI에 0f 표시를 위해 강제 설정

        // [옵저버 패턴] Board 등 구독자들에게 모든 카드를 뒤집으라고 알립니다.
        OnAllCardsFlip?.Invoke();

        yield return new WaitForSeconds(1.5f);

        fail.SetActive(true); // 실패 UI 활성화
    }

    public void GameVictory()
    {
        StartCoroutine(GameVictoryRoutine());
    }

    IEnumerator GameVictoryRoutine()
    {
        // BGM 피치 원상 복구 및 승리 사운드 재생
        AudioManager.Instance.ResetBgmPitch();
        AudioManager.Instance.PlayOneShot("clear");

        isClookTick = false; // 플래그 초기화

        // [데이터 저장] 클리어 레벨이 이전 최대 레벨보다 높을 때만 갱신 (데이터 무결성 유지)
        int clearedLevel = currentLevel + 1;
        int maxClearedLevel = PlayerPrefs.GetInt("ClearLevel", 0);

        if (clearedLevel > maxClearedLevel)
            PlayerPrefs.SetInt("ClearLevel", clearedLevel);

        isPlay = false; // 게임 중지

        yield return new WaitForSeconds(1.5f);

        success.SetActive(true); // 승리 UI 활성화
    }
}
