using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnClick()
    {
        ButtonManager.Instance.RestartGame();
    }
}
