using UnityEngine;

/// <summary>
/// [ButtonBaseWithTarget]
/// 특정 GameObject (예: 팝업 패널, 다른 오브젝트)를 인스펙터에서 참조해야 하는 버튼들이
/// 상속받는 기본 클래스입니다.
/// </summary>
public abstract class ButtonBaseWithTarget : ButtonBase // 기존 ButtonBase를 상속받습니다.
{
    // 자식 클래스들이 공통으로 사용할 GameObject 참조 변수
    // 이 변수에 인스펙터에서 팝업 UI를 연결합니다.
    [SerializeField]
    protected GameObject targetObject;

    // OnAwake, OnEnable, OnDisable, button 변수는 모두 ButtonBase에서 상속받아 사용합니다.

    // targetObject를 사용하여 원하는 액션을 구현하는 것은 자식 클래스의 책임입니다.
}