using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void PlayClickSound()
    {
        // AudioManager.Instance.....
    }

    public void StartGame()
    {
        PlayClickSound();
        SceneManager.LoadScene("MainScene");
    }

    public void RestartGame()
    {
        PlayClickSound();
        SceneManager.LoadScene("StartScene");
    }

    public void PauseGame()
    {
        PlayClickSound();
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        PlayClickSound();
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        PlayClickSound();
        Application.Quit();
    }

    public void Setting()
    {
        PlayClickSound();
    }
}