using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenu : UI_Window
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button startButton;

    public override void Initialize()
    {
        base.Initialize();
        settingsButton.onClick.AddListener(OpenSettings);
        startButton.onClick.AddListener(StartingGame);
    }   

    private void OnDestroy()
    {
        settingsButton.onClick.RemoveListener(OpenSettings);
        startButton.onClick.RemoveListener(StartingGame);
    }

    private void OpenSettings()
    {
        UI_Manager.instance.ShowUI(IDWindow.Settings);
    }

    private void StartingGame()
    {
        Hide();
    }

}
