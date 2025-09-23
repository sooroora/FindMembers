using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnPauseClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnPauseClick);
    }

    private void OnPauseClick()
    {
        ButtonManager.Instance.PauseGame();
    }
}
