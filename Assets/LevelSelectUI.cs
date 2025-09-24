using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelSelectUI : MonoBehaviour
{
    // 1. 난이도가 많으면 배열로 만들어서...
    [SerializeField] private GameObject btnNormal;
    [SerializeField] private GameObject btnNormalLock;
    [SerializeField] private GameObject btnHard;
    [SerializeField] private GameObject btnHardLock;


    void Awake()
    {
      
        if (PlayerPrefs.HasKey("ClearLevel"))
        {
            int nowLevel = PlayerPrefs.GetInt("ClearLevel");
            
            // 2. for문 돌려서 할 수도 있음...
            if(nowLevel == 1)
            {
                btnNormal.SetActive(true);
                btnNormalLock.SetActive(false);
            }
            else if(nowLevel == 2)
            {
                btnNormal.SetActive(true);
                btnNormalLock.SetActive(false);
                btnHard.SetActive(true);
                btnHardLock.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[CustomEditor(typeof(LevelSelectUI))]
public class LevelSelectTest : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        if(GUILayout.Button("EASY 클리어"))
        {
            SetClearLevel(1);
        }
        
        if(GUILayout.Button("NORMAL 클리어"))
        {
            SetClearLevel(2);            
        }
        
        if(GUILayout.Button("클리어 단계 초기화"))
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
