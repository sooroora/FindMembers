
public class PauseButton : ButtonBaseWithTarget
{
    protected override void OnButtonClick()
    {
        ButtonManager.Instance.PauseGame();
        UIManager.Instance.OpenUI(targetObject);
    }
}
