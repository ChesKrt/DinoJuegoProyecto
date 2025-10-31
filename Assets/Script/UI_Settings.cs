using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : UI_Window
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button creditButton;
    
    public bool isFromInGame = false;
    
    public override void Initialize()
    {
        base.Initialize();
        closeButton.onClick.AddListener(() => CloseWindow(isFromInGame));
    }
    
    private void OnDestroy()
    {
        closeButton.onClick.RemoveListener(() => CloseWindow(isFromInGame));
    }

    private void CloseWindow(bool isFromInGame = false)
    {
        AudioManager.instance.ApplyChange();

        if (isFromInGame)
        {
            Hide();
            UI_Manager.instance.ShowUI(IDWindow.InGame);
            GameManager.instance.obstacleSpawner.startSpawning = true;
        }
        else
        {
            Hide();
            UI_Manager.instance.ShowUI(IDWindow.MainMenu, true);
        }
    }
}
