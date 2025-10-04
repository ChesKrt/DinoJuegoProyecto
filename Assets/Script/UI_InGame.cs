using UnityEngine;
using UnityEngine.UI;

public class UI_InGame : UI_Window
{
    
    [SerializeField] private Button _configurationButton;
    [SerializeField] private Button _moveLeftButton;
    [SerializeField] private Button _moveRightButton;

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
        UI_Manager.instance.ShowUI(IDWindow.Settings);
    }
    
    private void MoveLeft()
    {
        Player.instance.MoveLeft();
    }

    private void MoveRight()
    {
        Player.instance.MoveRight();
    }
}
