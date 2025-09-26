
public class ResumeButton : ButtonBase
{
    protected override void OnButtonClick()
    {
        ButtonManager.Instance.ResumeGame();
        UIManager.Instance.CloseUI();
    }
}
