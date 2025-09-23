using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FailScore : MonoBehaviour
{
    private void OnEnable()
    {
        TextMeshProUGUI failText = GetComponent<TextMeshProUGUI>();
        failText.text = "남은 카드 수 : " + GameManager.Instance.cardCount.ToString();
    }

}
