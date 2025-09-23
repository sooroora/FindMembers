using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnGameStartClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnGameStartClick);
    }

    private void OnGameStartClick()
    {
        ButtonManager.Instance.StartGame();
    }
}
