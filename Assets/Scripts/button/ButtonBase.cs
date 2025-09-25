using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 모든 버튼 컴포넌트 스크립트가 상속받는 기본 클래스입니다.
/// 버튼 초기화 및 이벤트 등록/해지 로직을 공통으로 처리합니다.
/// </summary>
public abstract class ButtonBase : MonoBehaviour
{
    protected Button button; // 자식 클래스에서 접근 가능하도록 protected로 선언

    private void Awake()
    {
        // 1. 버튼 컴포넌트 초기화는 모든 버튼의 공통 책임
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        // 2. 이벤트 등록 로직도 모든 버튼의 공통 책임
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        // 3. 이벤트 해지 로직도 모든 버튼의 공통 책임
        button.onClick.RemoveListener(OnButtonClick);
    }

    /// <summary>
    /// [템플릿 메서드] 버튼 클릭 시 호출되는 추상 메서드입니다.
    /// 실제 버튼이 수행할 액션은 자식 클래스에서 반드시 구현해야 합니다.
    /// </summary>
    protected abstract void OnButtonClick();
}