using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 이 컴포넌트가 부착된 영역을 클릭하면 UIManager에 팝업 닫기를 요청합니다.
/// 팝업의 투명 배경 패널에 부착하여 허공 클릭 닫기 기능을 구현합니다.
/// </summary>
public class CloseOnOutsideClick : MonoBehaviour, IPointerClickHandler
{
    // IPointerClickHandler 인터페이스 구현
    public void OnPointerClick(PointerEventData eventData)
    {
        // 팝업 영역 밖(ModalBackground)이 클릭되면 실행됩니다.

        if (UIManager.Instance != null)
        {
            // UIManager에 스택 최상단 팝업 닫기를 요청합니다.
            UIManager.Instance.CloseUI();

            // 만약 ButtonManager의 클릭 사운드도 필요하다면 아래 코드를 추가합니다.
            // ButtonManager.Instance.ClosePopup(); 
        }
    }
}