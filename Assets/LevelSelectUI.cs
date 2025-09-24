using System.Collections;
using System.Collections.Generic;
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
