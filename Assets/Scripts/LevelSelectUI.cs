using UnityEditor;
using UnityEngine;

/*
 *  난이도 선택을 하는 UI를 제어하는 스크립트 입니다.
 *  스크립트 내에 각 난이도 별 버튼을 설정하여 조건에 맞을 때 락을 풀어줍니다. 
 */
public class LevelSelectUI : MonoBehaviour
{
    // 1. 현재는 난이도 갯수가 적어 게임오브젝트를 하나씩 선언하였습니다.
    // 버튼들은 인스펙터에서 드래그앤드롭으로 연결할 수 있습니다.
    [SerializeField] private GameObject btnNormal;
    [SerializeField] private GameObject btnNormalLock;
    [SerializeField] private GameObject btnHard;
    [SerializeField] private GameObject btnHardLock;


    [Space(10)] // 인스펙터의 LevelSelectUI 컴포넌트에서 여백을 줄 수 있습니다.
    // 히든 스테이지 버튼입니다. 
    [SerializeField]
    private GameObject btnHidden;

    // 히든 스테이지를 열 때, UI 백 이미지의 사이즈를 조절할 수 있도록 RectTransform 을 가져옵니다.
    [SerializeField] private RectTransform backImgRect;


    void Awake()
    {
        // PlayerPrefs 에 "ClearLevel" 의 키가 존재하는지 
        if (PlayerPrefs.HasKey("ClearLevel"))
        {   
            // "ClearLevel" 을 편히 쓸 수 있게 nowLevel 로 사용합니다.
            int nowLevel = PlayerPrefs.GetInt("ClearLevel");

            // 2. 만약 난이도가 많아 1번에서 버튼을 배열로 설정했다면 이 부분을 for문으로 돌려
            // 난이도 버튼 별로 lock을 푸는 방법도 있습니다.
            
            // 이지 모드를 클리어했다면 상현님의 GameManager 에서 "ClearLevel" 을 1로 설정해준 것을 받아옵니다.
            // nowLevel 이 1일 경우, 노말 스테이지가 해금됩니다.
            if (nowLevel == 1)
            {
                btnNormal.SetActive(true);
                btnNormalLock.SetActive(false);
            }
            else if (nowLevel == 2) // 노말, 하드 스테이지 해금
            {
                btnNormal.SetActive(true);
                btnNormalLock.SetActive(false);
                btnHard.SetActive(true);
                btnHardLock.SetActive(false);
            }
            else if (nowLevel == 3) // 노말, 하드, 히든 해금
            {
                btnNormal.SetActive(true);
                btnNormalLock.SetActive(false);
                btnHard.SetActive(true);
                btnHardLock.SetActive(false);
                btnHidden.SetActive(true);
                
                // 감춰져있던 히든 스테이지 버튼을 위해 백패널 이미지의 길이를 늘려줍니다.
                backImgRect.sizeDelta = backImgRect.sizeDelta + (Vector2.up * 90f);
            }
        }
    }
}

/*
 *  유니티 에디터에서만 돌 수 있게 전처리문을 추가했습니다.
 *  스테이지 해금을 테스트할 수 있도록 인스펙터에 버튼을 추가해주기 위해 작성했습니다.
 */
#if UNITY_EDITOR
[CustomEditor(typeof(LevelSelectUI))]
public class LevelSelectTest : Editor
{
    public override void OnInspectorGUI()
    {
        // LevelSelectUI의 기본 인스펙터 내용 그대로 사용
        base.OnInspectorGUI();

        // 그 아래에 버튼 추가
        GUILayout.Space(10);
        GUILayout.Label("레벨 디버그");
        
        // 인스펙터 내 해당 버튼을 클릭했다면...
        if (GUILayout.Button("EASY 클리어"))
        {   
            // "ClearLevel" 을 1로 설정합니다.
            SetClearLevel(1);
        }

        if (GUILayout.Button("NORMAL 클리어"))
        {
            SetClearLevel(2);
        }

        if (GUILayout.Button("지옥 난이도 열기"))
        {
            SetClearLevel(3);
        }
        
        // "ClearLevel" 을 삭제합니다. 
        if (GUILayout.Button("클리어 단계 초기화"))
        {
            ResetClearLevel();
        }
    }

    void SetClearLevel(int level)
    {
        PlayerPrefs.SetInt("ClearLevel", level);
    }

    void ResetClearLevel()
    {
        PlayerPrefs.DeleteKey("ClearLevel");
    }
}
#endif
