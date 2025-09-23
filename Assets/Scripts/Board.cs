using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;

    void Start()
    {
        if(GameManager.Instance.currentLevel == 0)
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
        if (GameManager.Instance.currentLevel == 0)
        {
            int[] arr = new int[pair * 2];
            for (int i = 0; i < pair; i++)
            {
                arr[i * 2] = i;
                arr[i * 2 + 1] = i;
            }

            arr = arr.OrderBy(x => Random.Range(0, 1000)).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                float x = (i % 4) * 1.4f - 2.1f;
                float y = (i / 4) * 1.4f - 3.0f;

                GameObject obj = Instantiate(card, this.transform);
                obj.transform.position = new Vector2(x, y);
                obj.GetComponent<Card>().Setting(arr[i]);
            }

            GameManager.Instance.cardCount = arr.Length;
        }
    }
}
