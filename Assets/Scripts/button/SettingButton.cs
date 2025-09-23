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

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            ButtonManager.Instance.Setting();
            UIManager.Instance.OpenUI(settingPanel);
        });
    }
}