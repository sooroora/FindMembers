using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePopupButton : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();

    }
    private void OnEnable()
    {
        button.onClick.AddListener(ClosePopup);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(ClosePopup);
    }

    private void ClosePopup()
    {
        ButtonManager.Instance.ClosePopup();
        UIManager.Instance.CloseUI();
    }
}
