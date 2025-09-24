using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnRestartClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnRestartClick);
    }

    private void OnRestartClick()
    {
        ButtonManager.Instance.LoadMainScene();
    }
}
