
using UnityEngine;
using UnityEngine.UI;

public class LoadStartSceneButton : MonoBehaviour
{
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(OnLoadStartSceneClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(OnLoadStartSceneClick);
    }

    private void OnLoadStartSceneClick()
    {
        ButtonManager.Instance.LoadStartScene();
    }
}
