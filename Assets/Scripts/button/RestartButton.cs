
public class RestartButton : ButtonBase
{
    protected override void OnButtonClick()
    {
        ButtonManager.Instance.LoadMainScene();
    }
}
