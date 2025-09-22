using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject card;
    public int pair = 8;

    void Start()
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

        //GameManager.instance.cardCount = arr.Length;
    }
}
