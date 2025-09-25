using UnityEngine;
using UnityEngine.UI;

/*
 *  상현님의 Button 스크립트 규칙에 맞추어 PopupUI 를 Open 하는 버튼 스크립트 입니다.
 *  버튼 컴포넌트의 OnClick을 사용하지 않고 해당 스크립트 부착만으로 사용할 수 있도록 작성되었습니다.
 */
public class OpenPopupButton : MonoBehaviour
{
    // 해당 버튼이 띄울 popup 오브젝트를 인스펙터에서 설정해야합니다.
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
        // Popup이 오픈될 때 동작할 함수를 실행합니다.
        ButtonManager.Instance.OpenPopup();
        // UIManager 에도 현재 오픈하는 팝업을 건네줍니다.
        UIManager.Instance.OpenUI(popup);
    }
}
