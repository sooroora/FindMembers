using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePopupButton : MonoBehaviour
{
    Button button;
    
    void Awake()
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(() =>
        {
            // 근데 요러면 스택보다는 ClosePopupButton 이 들어간 아무 X button을 누르면
            // 제일 최근 열린 UI 가 닫히는거라 애매한 상태ㅋㅋㅋ 큐ㅠㅠ..
            // 뒤로가기를 눌렀다면 제일 최근 UI가 닫히면 좋고 팝업의 X를 눌렀을땐 해당하는 팝업을 지우게 수정해야함
            UIManager.Instance.CloseUI();
        });
    }

}
