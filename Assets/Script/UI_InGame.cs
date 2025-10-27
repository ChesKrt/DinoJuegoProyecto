using System;   
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : UI_Window
{
    
    [SerializeField] private Button _configurationButton;
    [SerializeField] private Button _moveLeftButton;
    [SerializeField] private Button _moveRightButton;
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    public override void Initialize()
    {
        base.Initialize();
        _configurationButton.onClick.AddListener(OpenConfiguration);
        _moveLeftButton.onClick.AddListener(MoveLeft);
        _moveRightButton.onClick.AddListener(MoveRight);
    }

    public void OnDisable()
    {
        _configurationButton.onClick.RemoveListener(OpenConfiguration);
        _moveLeftButton.onClick.RemoveListener(MoveLeft);
        _moveRightButton.onClick.RemoveListener(MoveRight);
    }
    
    private void OpenConfiguration()
    {
        UI_Settings uiSettings = UI_Manager.instance.GetWindow(IDWindow.Settings) as UI_Settings;
        uiSettings.isFromInGame = true;
        UI_Manager.instance.ShowUI(IDWindow.Settings);
        GameManager.instance.obstacleSpawner.startSpawning = false;
    }
    
    private void MoveLeft()
    {
        Player.instance.MoveLeft();
    }

    private void MoveRight()
    {
        Player.instance.MoveRight();
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }
}
