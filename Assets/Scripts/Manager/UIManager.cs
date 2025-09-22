using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private readonly Stack<GameObject> uiStack = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OpenUI(GameObject newUI)
    {
        if (uiStack.Count > 0)
            uiStack.Peek().SetActive(false);

        newUI.SetActive(true);
        uiStack.Push(newUI);
    }

    public void CloseUI()
    {
        if (uiStack.Count > 0)
        {
            GameObject currentUI = uiStack.Pop();
            currentUI.SetActive(false);

            if (uiStack.Count > 0)
                uiStack.Peek().SetActive(true);
        }
    }
}