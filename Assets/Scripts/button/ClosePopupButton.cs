using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePopupButton : MonoBehaviour
{
    [SerializeField] private GameObject popup;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();

    }
    private void OnEnable()
    {
        button.onClick.AddListener(OpenPopup);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OpenPopup);
    }

    private void OpenPopup()
    {
        ButtonManager.Instance.ClosePopup();
        UIManager.Instance.OpenUI(popup);
    }
}
