using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    
    public ObstacleSpawner obstacleSpawner;

    public UnityEvent<bool> StartingPinguGame = new UnityEvent<bool>();
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

    public void GameStarted(bool isGameStarted = false)
    {
        if (isGameStarted)
        {
            obstacleSpawner.startSpawning = true;
        }
    }
    
}
