using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessUI : MonoBehaviour
{
    int list = 0;
    string[] arr = { "전수라", "양채윤", "황준영", "정재우", "박상현" };
    public Text nameTxt;

    void Start()
    {

    }

    void Update()
    {
        nameTxt.text = arr[0];
    }


}
