using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(-100)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;   

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject success;
    [SerializeField] GameObject fail;

    public Card firstCard;
    public Card secondCard;
    public float cardCount;
    public int currentLevel; // Easy 0. Moraml 1, Hard 2
    public bool isLock;
    public Action OnAllCardsFlip;
    public bool isPlay;
    public float time;

    private bool isClookTick;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("level", 0);

        time = 60f;
    }

    private void Update()
    {
        if (!isPlay)
            return;

        time -= Time.deltaTime;
        timeText.text = time.ToString("F2");

        if (time <= 10f && !isClookTick)
        {
            AudioManager.Instance.UpdateBgmPitch();
            AudioManager.Instance.PlayOneShot("ClookTicking");
            isClookTick = true;
        }

        if (time <= 0f)
        {
            GameOver();
        } 
    }

    public void Matched()
    {
        isLock = true;

        if (firstCard.idx == secondCard.idx)
        {
            // 파괴해라
            StartCoroutine(DelayPlay(0.3f, () => AudioManager.Instance.PlayOneShot("Matched")));

            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
                GameVictory();
        }
        else
        {
            // 닫아라
            StartCoroutine(DelayPlay(0.3f, () => AudioManager.Instance.PlayOneShot("Failed")));

            firstCard.ClosedCard();
            secondCard.ClosedCard();
        }

        firstCard = null;
        secondCard = null;
    }

    IEnumerator DelayPlay(float delay, UnityAction action)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }

    public void UnLock()
    {
        isLock = false;
    }

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
        AudioManager.Instance.ResetBgmPitch();
        AudioManager.Instance.PlayOneShot("TimeOver");

        isClookTick = false;

        isPlay = false;

        time = 0f;

        OnAllCardsFlip?.Invoke();

        yield return new WaitForSeconds(1.5f);

        fail.SetActive(true);
    }

    public void GameVictory()
    {
        StartCoroutine(GameVictoryRoutine());
    }

    IEnumerator GameVictoryRoutine()
    {
        AudioManager.Instance.ResetBgmPitch();
        AudioManager.Instance.PlayOneShot("clear");

        isClookTick = false;

        int clearedLevel = currentLevel + 1;
        int maxClearedLevel = PlayerPrefs.GetInt("ClearLevel", 0);

        if (clearedLevel > maxClearedLevel)
            PlayerPrefs.SetInt("ClearLevel", clearedLevel);

        isPlay = false;

        yield return new WaitForSeconds(1.5f);

        success.SetActive(true);
    }
}
