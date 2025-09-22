using UnityEngine;

public class GameStartButton : MonoBehaviour
{
    public void OnClick()
    {
        ButtonManager.Instance.StartGame();
    }
}
