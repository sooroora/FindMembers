
public class QuitButton : ButtonBase
{
    protected override void OnButtonClick()
    {
        ButtonManager.Instance.QuitGame();
    }
}
