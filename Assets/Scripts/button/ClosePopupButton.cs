using UnityEngine;
using UnityEngine.UI;

/*
 *
 *  OpenPopupButton 과 반대 역할을 수행합니다.
 *  팝업의 X 버튼에 부착하여 사용합니다.
 *    
 */
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
        // 팝업을 닫을 때 동작할 함수를 실행합니다.
        ButtonManager.Instance.ClosePopup();
        // UIManager 가 현재 오픈되어있는 PopupUI 를 알고있으니, CloseUI 함수를 통해 닫아줍니다.
        UIManager.Instance.CloseUI();
    }
}
