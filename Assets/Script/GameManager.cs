using UnityEngine;
using UnityEngine.Events;
using System.IO;
using NaughtyAttributes;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public ObstacleSpawner obstacleSpawner;
    public Player player;

    public UnityEvent<bool> StartingPinguGame { private get; set; } = new UnityEvent<bool>();

    public int score;
    private int _bestScore;

    private string pathOfFile;
    private string readJsonFile;
    private PlayerStats playerStats;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        pathOfFile = Path.Combine(Application.persistentDataPath, "PlayerStats.json");
    }

    void Update()
    {
        SentScoreToUI();
    }

    public void GameStarted(bool isGameStarted = false)
    {
        if (isGameStarted)
        {
            score = 0;
            UI_Manager.instance.ShowUI(IDWindow.InGame, true);
            player.transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z);
            obstacleSpawner.startSpawning = true;
            AudioManager.instance.PlayBackgroundMusic(0);
        }
    }

    public void GameFinished(bool isGameFinished = false)
    {
        if (isGameFinished)
        {
            obstacleSpawner.startSpawning = false;
            UI_Manager.instance.CloseUI(IDWindow.InGame, true);
            UI_Manager.instance.ShowUI(IDWindow.Lose);
            ScoreUpdated();
            SentBestScore();
            AudioManager.instance.StopBackgroundMusic(0);
        }
    }

    public void SentScoreToUI()
    {
        UI_InGame inGameUI = UI_Manager.instance.GetWindow(IDWindow.InGame) as UI_InGame;
        if (inGameUI != null)
        {
            inGameUI.UpdateScore(score);
        }
    }

    public void SentBestScore()
    {
        UI_Lose loseUI = UI_Manager.instance.GetWindow(IDWindow.Lose) as UI_Lose;
        if (loseUI != null)
        {
            loseUI.UpdateBestScore(_bestScore);
        }
    }

    private void ScoreUpdated()
    {
        if (!File.Exists(pathOfFile))
        {
            File.WriteAllText(pathOfFile, ConstanceJson.ANDROID_JSON);
        }

        readJsonFile = File.ReadAllText(pathOfFile);
        playerStats = JsonUtility.FromJson<PlayerStats>(readJsonFile);

        if (score > playerStats.playerBestScore)
        {
            playerStats.playerBestScore = score;
        }

        _bestScore = playerStats.playerBestScore;

        readJsonFile = JsonUtility.ToJson(playerStats, true);
        File.WriteAllText(pathOfFile, readJsonFile);
    }

    [Button]
    void TestOpenGameUI()
    {
        UI_Manager.instance.ShowUI(IDWindow.InGame);
    }

    [Button]
    void TestHideGameUI()
    {
        UI_Manager.instance.CloseUI(IDWindow.InGame);
    }


}
public class ConstanceJson
{
    public const string ANDROID_JSON = "{\n    \"playerBestScore\": 0,\n    \"playerBestScores\": []\n}";
    public static string VOLUME;
}
