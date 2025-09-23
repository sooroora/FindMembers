using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnQuitButton);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnQuitButton);
    }

    private void OnQuitButton()
    {
        ButtonManager.Instance.QuitGame();
    }
}
