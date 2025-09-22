using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void OnClick()
    {
        ButtonManager.Instance.QuitGame();
    }
}
