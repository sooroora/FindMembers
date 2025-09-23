using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    private float time;
    private bool isPlay;

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

    private void Update()
    {
        if (!isPlay)
            return;

        time += Time.deltaTime;
        timeText.text = time.ToString("F2");

        if (time >= 30.0f)
        {
            GameOver();
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            // 파괴해라
            //AudioManager.Instantiate...

            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
                GameOver();
        }
        else
        {
            // 닫아라
            firstCard.ClosedCard();
            secondCard.ClosedCard();
        }

        firstCard = null;
        secondCard = null;
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
        isPlay = false;

        yield return new WaitForSeconds(1.5f);

        fail.SetActive(true);
    }

    public void GameVictory()
    {
        StartCoroutine(GameVictoryRoutine());
    }

    IEnumerator GameVictoryRoutine()
    {
        isPlay = false;

        yield return new WaitForSeconds(1.5f);

        success.SetActive(true);
    }
}
