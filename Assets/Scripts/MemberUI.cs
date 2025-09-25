using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberUI : MonoBehaviour
{
    public GameObject listPanel;
    public GameObject memberPanel;
    public SuccessUI memberCtrl;
    public GameObject bgPanel;
    public void OpenPanel(int memberIndex)
    {
        listPanel.SetActive(false);
        memberPanel.SetActive(true);
        memberCtrl.SetMember(memberIndex);  //선택한 멤버 정보를 SuccessUI에 전달
    }
    public void ClosePanel()
    {
        memberPanel.SetActive(false);
        bgPanel.SetActive(false);
        listPanel.SetActive(true);
    }
}
