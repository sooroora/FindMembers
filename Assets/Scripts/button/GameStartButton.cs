using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    private Button button;
    [SerializeField] private int level;

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
        PlayerPrefs.SetInt("level", level);
        ButtonManager.Instance.StartGame();
    }
}
