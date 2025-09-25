using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnResumeClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnResumeClick);
    }

    private void OnResumeClick()
    {
        ButtonManager.Instance.ResumeGame();
        UIManager.Instance.CloseUI();
    }
}
