using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    // 카드 프리팹 (인스펙터에서 할당)
    public Card card;

    // 현재 보드에 존재하는 카드들을 담는 리스트
    private List<Card> cardList = new List<Card>();

    // 게임 오브젝트가 활성화될 때(GameObject.SetActive(true))
    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            // GameManager에서 OnAllCardsFlip 이벤트 구독
            GameManager.Instance.OnAllCardsFlip += AllCardOpen;
        }
    }

    // 게임 오브젝트가 비활성화될 때(GameObject.SetActive(false))
    private void OnDisable()
    {
        if (GameManager.Instance != null)
            // 이벤트 구독 해제 (메모리 누수 방지)
            GameManager.Instance.OnAllCardsFlip -= AllCardOpen;
    }

    // 모든 카드를 강제로 뒤집는 동작(게임에서 패배했을 때)
    private void AllCardOpen()
    {
        foreach (Card c in cardList)
        {
            if (c != null)
                c.FailOpenCard(); // 카드의 FailOpenCard 실행
        }
    }

    // 시작 시 난이도에 따라 보드 생성
    void Start()
    {
        if (GameManager.Instance.currentLevel == 0)
        {
            BoardSetting(8);   // 8쌍 → 총 16장
        }
        else if (GameManager.Instance.currentLevel == 1)
        {
            BoardSetting(10);  // 10쌍 → 총 20장
        }
        else if (GameManager.Instance.currentLevel >= 2)
        {
            BoardSetting(15);  // 15쌍 → 총 30장
        }
    }

    // 보드 세팅: 카드 쌍 생성 및 랜덤 섞기
    private void BoardSetting(int pair)
    {
        // 카드 번호 배열 생성 (짝 2장씩)
        int[] arr = new int[pair * 2];
        for (int i = 0; i < pair; i++)
        {
            arr[i * 2] = i;
            arr[i * 2 + 1] = i;
        }

        // 배열 랜덤 셔플
        arr = arr.OrderBy(x => Random.Range(0, 1000)).ToArray();

        // 현재 레벨에 따라 보드 배치 (그리드 크기, 간격, 시작 위치 달라짐)
        if (GameManager.Instance.currentLevel == 0)
        {
            StartCoroutine(DelayAnimation(arr, 4, 1.4f, -2.1f, -3.0f));
        }

        if (GameManager.Instance.currentLevel == 1)
        {
            StartCoroutine(DelayAnimation(arr, 4, 1.4f, -2.1f, -4.2f));
        }

        if (GameManager.Instance.currentLevel >= 2)
        {
            StartCoroutine(DelayAnimation(arr, 5, 1.15f, -2.3f, -4.2f));
        }

        // 총 카드 개수를 GameManager에 전달
        GameManager.Instance.cardCount = arr.Length;
    }

    // 카드 생성 및 배치 코루틴
    IEnumerator DelayAnimation(int[] arr, int widthCount, float cardSpacing, float xStart, float yStart)
    {
        cardList.Clear(); // 카드 리스트 초기화

        for (int i = 0; i < arr.Length; i++)
        {
            // 카드 배치 좌표 계산
            float x = (i % widthCount) * cardSpacing + xStart;
            float y = (i / widthCount) * cardSpacing + yStart;

            // 카드 생성 및 세팅
            Card obj = Instantiate(card);
            obj.transform.position = new Vector2(x, y);
            obj.Setting(arr[i]); // 카드 번호 세팅
            AudioManager.Instance.PlayOneShot("CardFlip"); // 카드 놓일 때 효과음
            cardList.Add(obj);

            // 카드 하나 생성할 때마다 0.1초 대기 (애니메이션 효과)
            yield return new WaitForSeconds(0.1f);
        }

        // 모든 카드가 생성된 후 카드 활성화
        foreach (Card c in cardList)
        {
            c.ActivateCard();
        }

        // 보드 세팅이 끝났으므로 게임 시작 신호를 게임 매니저로
        GameManager.Instance.GameStart();
    }
}
