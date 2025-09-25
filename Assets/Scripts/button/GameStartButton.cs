using UnityEngine;

/// <summary>
/// LevelSelectUI 내 버튼이 가지고 있는 버튼 클래스 입니다.
/// 버튼마다 레벨을 설정하고 게임을 진행하는 MainScene으로 현재 선택한 레벨을 넘겨줄 수 있게 작성했습니다.
/// </summary>
public class GameStartButton : ButtonBase
{
    // 버튼의 레벨을 인스펙터에서 설정합니다.
    [SerializeField] private int level;

    protected override void OnButtonClick()
    {
        // PlayerPrefs 에 "level" 값을 해당 스크립트의 "level" 을 설정해줍니다.
        // GameManager와 Board 에서 해당 값을 확인하여 게임을 진행합니다.
        PlayerPrefs.SetInt("level", level);

        // 레벨 설정 후 MainScene으로 이동합니다.
        ButtonManager.Instance.LoadMainScene();
    }
}
