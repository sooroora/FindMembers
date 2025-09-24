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

    public void LoadMainScene()
    {
        PlayClickSound();
        SceneManager.LoadScene("MainScene");
    }

    public void LoadStartScene()
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
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OpenPopup()
    {
        PlayClickSound();
    }

    public void ClosePopup()
    {
        PlayClickSound();
    }
}