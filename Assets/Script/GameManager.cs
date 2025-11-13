using DG.Tweening;
using NaughtyAttributes;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public ObstacleSpawner obstacleSpawner;
    public Player player;

    public GameObject[] MainMenu;
    public Vector2 menuOut;

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
            GameMenuStarte(true);
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

    public void GameMenuStarte(bool starting = false)
    {

        if (starting)
        {
            float target01 = Mathf.Clamp(transform.position.x + 10, -10, 10);
            MainMenu[0].transform.DOMoveX(target01, menuOut.x);
            MainMenu[1].transform.DOMoveX(target01, menuOut.x);
        }
        else
        {
            float target02 = Mathf.Clamp(transform.position.x + 0, 0, 10);
            MainMenu[0].transform.DOMoveX(target02, menuOut.y);
            MainMenu[1].transform.DOMoveX(target02, menuOut.y);
        }
    }
}
public class ConstanceJson
{
    public const string ANDROID_JSON = "{\n    \"playerBestScore\": 0,\n    \"playerBestScores\": []\n}";
    public static string VOLUME;
}
