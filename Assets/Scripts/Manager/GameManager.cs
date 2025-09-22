using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Text timeText;
    [SerializeField] GameObject endText;
    [SerializeField] AudioClip clip;

    public Card firstCard;
    public Card secondCard;
    public float cardCount;

    private float time;
    private AudioSource audioSource;

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
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("F2");

        if (time >= 30.0f)
        {
            GameOver();
            time = 30.0f;
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            // 파괴해라
            audioSource.PlayOneShot(clip);

            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;

            if (cardCount == 0)
                GameOver();
        }
        else
        {
            // 닫아라
            //firstCard.ClosedCard();
            //secondCard.ClosedCard();
        }

        firstCard = null;
        secondCard = null;
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        endText.SetActive(true);
    }
}
