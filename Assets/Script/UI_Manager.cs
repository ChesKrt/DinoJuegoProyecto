using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    
    [SerializeField] private List<UI_Window> uiWindows;
    
    public void ShowUI(string windowUI, bool instant = false)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowId == windowUI)
            {
                window.Show(instant);
                return;
            }
        }
    }

    public void CloseUI(string windowUI, bool instant = false)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowId == windowUI)
            {
                window.Hide(instant);
                return;
            }
        }
    }

    public void CloseAllWindows()
    {
        foreach (var window in uiWindows)
        {
            window.Hide();
        }
    }

    public UI_Window GetWindow(string windowUI)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowId == windowUI)
            {
                return window;
            }
        }
        return null;
    }

    #region Editor
    [Button]
    private void GetAllWindows()
    {
        uiWindows.Clear();
        UI_Window[] windows = FindObjectsByType<UI_Window>(FindObjectsSortMode.InstanceID);
        uiWindows.AddRange(windows);
    }
    #endregion
    
    
}

public static class IDWindow
{
    public const string Settings = "Settings";
    public const string Lose = "Lose";
    public const string MainMenu = "MainMenu";
    public const string Inventory = "Inventory";
    public const string InGame = "InGame";
}
