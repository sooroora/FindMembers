using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuccessUI : MonoBehaviour
{
    int list = 0;
    string[] arr = { "������", "��ä��", "Ȳ�ؿ�", "�����", "�ڻ���" };
    public Text nameTxt;

    void Start()
    {

    }

    void Update()
    {
        nameTxt.text = arr[0];
    }


}
