using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Lose : UI_Window
{
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Button _buttonMainMenu;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    public override void Initialize()
    {
        base.Initialize();
        _buttonRestart.onClick.AddListener(Restart);
        _buttonMainMenu.onClick.AddListener(MainMenu);
    }

    void OnDisable()
    {
        _buttonRestart.onClick.RemoveListener(Restart);
        _buttonMainMenu.onClick.RemoveListener(MainMenu);
    }
    
    public void UpdateBestScore(int bestScore)
    {
        _bestScoreText.text = bestScore.ToString();
    }
    
    private void Restart()
    {
        UI_Manager.instance.ShowUI(IDWindow.InGame);
        // UI_InGame inGame = UI_Manager.instance.GetWindow(IDWindow.InGame) as UI_InGame;
        // inGame.HardCodeRectTransform();
        ObstacleSpawner.instance.spawnInterval = 2f;
        GameManager.instance.GameStarted(true);
        Hide(true);
    }
    
    private void MainMenu()
    {
        Hide(true);
        GameManager.instance.GameMenuStarte();
        UI_Manager.instance.ShowUI(IDWindow.MainMenu);
    }
}
