using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPopupButton : MonoBehaviour
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
        // 팝업 오픈 사운드 줄 추가 필요
        UIManager.Instance.OpenUI(popup.gameObject);
    }
}
