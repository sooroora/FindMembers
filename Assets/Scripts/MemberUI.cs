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
        memberCtrl.SetMember(memberIndex);
    }
    public void ClosePanel()
    {
        memberPanel.SetActive(false);
        bgPanel.SetActive(false);
    }
}
