using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberUI : MonoBehaviour
{

    public GameObject listPanel;
    public GameObject memberPanel;
    public SuccessUI memberCtrl;

    public void OpenPanel(int memberIndex)
    {
        listPanel.SetActive(false);
        memberPanel.SetActive(true);
        memberCtrl.SetMember(memberIndex);
    }
}
