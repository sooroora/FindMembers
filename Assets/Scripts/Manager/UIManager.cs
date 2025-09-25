using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// [UIManager]
/// 게임 내 모든 팝업 UI의 열기/닫기 순서와 생명주기를 관리하는 매니저입니다.
/// 단일 책임 원칙(SRP)에 따라 오직 UI 레이어 관리 책임만을 가집니다.
/// </summary>
public class UIManager : MonoBehaviour
{
    // [디자인 패턴: 싱글턴]
    // 게임 전체에서 유일한 인스턴스를 유지하여 어디서든 접근 가능하게 합니다.
    public static UIManager Instance;

    // [자료 구조: Stack]
    // UI의 계층(레이어) 순서를 관리합니다. LIFO(Last-In, First-Out) 방식으로,
    // 가장 마지막에 열린 팝업이 가장 위에 놓입니다.
    private readonly Stack<GameObject> uiStack = new();

    private void Awake()
    {
        // 싱글턴 초기화 로직
        if (Instance == null)
        {
            Instance = this;
            // 씬 전환 시에도 파괴되지 않도록 설정
            DontDestroyOnLoad(gameObject);

            // [디자인 패턴: 옵저버 패턴]
            // SceneManager.sceneLoaded 이벤트에 ClearStack 메서드를 구독합니다.
            // 씬이 로드될 때마다 스택이 자동으로 초기화되어 UI 오류를 방지합니다.
            SceneManager.sceneLoaded += ClearStack;
        }
        else
        {
            // 이미 인스턴스가 존재하면 새로운 오브젝트는 파괴
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // 오브젝트가 파괴될 때 메모리 누수를 방지하기 위해 이벤트 구독을 해지합니다.
        SceneManager.sceneLoaded -= ClearStack;
    }

    /// <summary>
    /// 씬 로드 완료 시 자동으로 호출되어 UI 스택을 초기화합니다.
    /// SceneManager.sceneLoaded 이벤트의 시그니처에 맞게 (Scene, LoadSceneMode) 인자를 받습니다.
    /// </summary>
    private void ClearStack(Scene scene, LoadSceneMode mode)
    {
        // 스택에 있는 모든 UI를 비활성화하고 스택에서 제거합니다.
        while (uiStack.Count > 0)
        {
            GameObject currentUI = uiStack.Pop();
            // 파괴된 오브젝트에 접근하는 MissingReferenceException을 방지하기 위해 null 체크를 합니다.
            if (currentUI != null)
                currentUI.SetActive(false);
        }
    }

    public void OpenUI(GameObject newUI)
    {
        if (newUI == null)
        {
            Debug.LogWarning("OpenUI에 전달된 GameObject가 null입니다. 작업을 중단합니다.");
            return;
        }

        newUI.SetActive(true);
        uiStack.Push(newUI);
    }

    public void CloseUI()
    {
        if (uiStack.Count > 0)
        {
            GameObject currentUI = uiStack.Pop();
            if (currentUI != null)
            {
                currentUI.SetActive(false);
            }

            if (uiStack.Count > 0)
                uiStack.Peek().SetActive(true);
        }
    }
}
