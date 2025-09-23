using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Card card;
    private List<Card> cardList = new List<Card>();

    void Start()
    {
        if (GameManager.Instance.currentLevel == 0)
        {
            BoardSetting(8);
        }
        else if (GameManager.Instance.currentLevel == 1)
        {
            BoardSetting(10);
        }
        else if (GameManager.Instance.currentLevel == 2)
        {
            BoardSetting(15);
        }
    }

    private void BoardSetting(int pair)
    {
        int[] arr = new int[pair * 2];
        for (int i = 0; i < pair; i++)
        {
            arr[i * 2] = i;
            arr[i * 2 + 1] = i;
        }

        arr = arr.OrderBy(x => Random.Range(0, 1000)).ToArray();

        if (GameManager.Instance.currentLevel == 0)
        {
            StartCoroutine(DelayAnimation(arr, 4, 1.4f, -2.1f, -3.0f));
        }

        if (GameManager.Instance.currentLevel == 1)
        {
            StartCoroutine(DelayAnimation(arr, 4, 1.4f, -2.1f, -4.2f));
        }

        if (GameManager.Instance.currentLevel == 2)
        {
            StartCoroutine(DelayAnimation(arr, 5, 1.15f, -2.3f, -4.2f));
        }

        GameManager.Instance.cardCount = arr.Length;
        GameManager.Instance.GameStart();
    }

    IEnumerator DelayAnimation(int[] arr, int widthCount, float cardSpacing, float xStart, float yStart)
    {
        cardList.Clear();

        for (int i = 0; i < arr.Length; i++)
        {
            float x = (i % widthCount) * cardSpacing + xStart;
            float y = (i / widthCount) * cardSpacing + yStart;

            Card obj = Instantiate(card);
            obj.transform.position = new Vector2(x, y);
            obj.Setting(arr[i]);

            cardList.Add(obj);

            yield return new WaitForSeconds(0.2f);
        }

        foreach (Card c in cardList)
        {
            c.ActivateCard();
        }
    }
}
