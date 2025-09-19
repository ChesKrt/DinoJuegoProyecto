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
    
    [SerializeField] private List<UIWindow> uiWindows;
    
    public void ShowUI(string windowUI)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowID == windowUI)
            {
                window.Show();
                return;
            }
        }
    }

    public void CloseUI(string windowUI)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowID == windowUI)
            {
                window.Hide();
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

    public UIWindow GetWindow(string windowUI)
    {
        foreach (var window in uiWindows)
        {
            if (window.WindowID == windowUI)
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
        UIWindow[] windows = FindObjectsByType<UIWindow>(FindObjectsSortMode.InstanceID);
        uiWindows.AddRange(windows);
    }
    #endregion
    
    
}

public static class IDWindow
{
    public static string Popup = "PopUp";
}
