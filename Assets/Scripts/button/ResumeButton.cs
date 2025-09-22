using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    public void OnClick()
    {
        ButtonManager.Instance.ResumeGame();
    }
}
