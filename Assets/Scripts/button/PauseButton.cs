using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void OnClick()
    {
        ButtonManager.Instance.PauseGame();
    }
}
