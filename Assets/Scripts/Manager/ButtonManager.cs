using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// [ButtonManager]
/// 게임 내 모든 UI 버튼 액션을 중계하고 공통 로직(클릭 사운드 등)을 처리하는 매니저입니다.
/// SOLID 원칙 중 단일 책임 원칙(SRP)에 따라 버튼 클릭의 후처리 및 Scene 전환 책임을 맡습니다.
/// </summary>
public class ButtonManager : MonoBehaviour
{
    // [디자인 패턴: 싱글턴]
    // 게임 전체에서 유일한 인스턴스를 유지하여 어디서든 접근 가능하게 합니다.
    public static ButtonManager Instance;

    private void Awake()
    {
        // 싱글턴 인스턴스 초기화 로직
        if (Instance == null)
        {
            Instance = this;
            // 씬 전환 시에도 파괴되지 않도록 설정 (DontDestroyOnLoad)
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 이미 인스턴스가 존재하면 새로운 오브젝트는 파괴하여 유일성을 보장
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 모든 버튼 클릭 시 공통으로 실행되는 사운드 재생 로직입니다.
    /// SRP에 따라 모든 버튼 액션의 오디오 처리를 이곳에서 캡슐화합니다.
    /// </summary>
    private void PlayClickSound()
    {
        // AudioManager의 PlayRandomClick 메서드를 호출하여 랜덤 클릭 사운드를 재생합니다.
        AudioManager.Instance.PlayRandomClick();
    }

    /// <summary>
    /// 메인 게임 씬으로 이동합니다.
    /// </summary>
    public void LoadMainScene()
    {
        PlayClickSound();
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// 시작(로비) 씬으로 이동합니다.
    /// </summary>
    public void LoadStartScene()
    {
        PlayClickSound();
        SceneManager.LoadScene("StartScene");
    }

    /// <summary>
    /// 게임을 일시 정지(TimeScale = 0)합니다.
    /// </summary>
    public void PauseGame()
    {
        PlayClickSound();
        Time.timeScale = 0f;
    }

    /// <summary>
    /// 일시 정지된 게임을 재개(TimeScale = 1)합니다.
    /// </summary>
    public void ResumeGame()
    {
        PlayClickSound();
        Time.timeScale = 1f;
    }

    /// <summary>
    /// 게임을 종료합니다. (빌드 환경과 에디터 환경 분리 필요 - 현재 에디터 전용)
    /// </summary>
    public void QuitGame()
    {
        PlayClickSound();

        // [#if UNITY_EDITOR] 전처리기: 이 코드는 Unity 에디터에서 실행될 때만 컴파일됩니다.
#if UNITY_EDITOR
        // 에디터에서 실행 중일 때는 에디터 재생을 멈춥니다.
        UnityEditor.EditorApplication.isPlaying = false;

        // [#else] 전처리기: 에디터가 아닌 (빌드된) 환경에서 실행될 때 컴파일됩니다.
#else
            // 빌드된 게임(PC, 모바일 등)에서는 애플리케이션을 종료합니다.
        Application.Quit()
#endif
    }

    /// <summary>
    /// 팝업을 여는 동작을 처리합니다. (주로 사운드 재생 용도)
    /// 실제 팝업 활성화 로직은 UIManager가 담당합니다. (SRP)
    /// </summary>
    public void OpenPopup()
    {
        PlayClickSound();
    }

    /// <summary>
    /// 팝업을 닫는 동작을 처리합니다. (주로 사운드 재생 용도)
    /// 실제 팝업 비활성화 로직은 UIManager가 담당합니다. (SRP)
    /// </summary>
    public void ClosePopup()
    {
        PlayClickSound();
    }
}
