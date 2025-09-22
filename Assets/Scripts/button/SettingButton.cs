using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;

    public void OnClick()
    {
        ButtonManager.Instance.Setting();
        UIManager.Instance.OpenUI(settingPanel);
    }
}