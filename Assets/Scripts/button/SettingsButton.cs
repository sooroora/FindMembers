using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject settingPanel;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnSettingsClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnSettingsClick);
    }

    private void OnSettingsClick()
    {
        ButtonManager.Instance.Setting();
        UIManager.Instance.OpenUI(settingPanel);
    }
}