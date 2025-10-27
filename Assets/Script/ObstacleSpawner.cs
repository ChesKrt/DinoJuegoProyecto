using System;
using NaughtyAttributes;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{

    public static ObstacleSpawner instance;
    
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private ObstacleDetector detector;

    private int _lastSpawn = 1;
    private float _timer = 0f;
    public float spawnInterval = 2f;
    [SerializeField] private int _scoreToIncreaseDifficulty = 10;
    
    private bool _changeSpawnInterval = true;
    
    public bool startSpawning = false;
    void OnEnable()
    {
        detector.OnObstacleDetected.AddListener(OnObstacleDetected);
    }
    
    void OnDisable()
    {
        detector.OnObstacleDetected.RemoveListener(OnObstacleDetected);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void OnObstacleDetected(GameObject obstacle)
    {
        DestroyObstacle(obstacle);
    }

    private void Update()
    {
        if (startSpawning)
        {
            if (GameManager.instance.score >= _scoreToIncreaseDifficulty && _changeSpawnInterval)
            {
                if (spawnInterval < 0.5f)
                {
                    _changeSpawnInterval = false;
                    return;
                }
                spawnInterval -= 0.2f;
                _scoreToIncreaseDifficulty += 10;
            }
            
            _timer += Time.deltaTime;
            if (_timer > spawnInterval)
            {
                SpawnObstacle();
                _timer = 0f;
            }
        }
    }

    [Button]
    public void SpawnObstacle()
    {
        List<int> spawns = new List<int>();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != _lastSpawn)
            {
                spawns.Add(i);
            }
        }
        
        int randomPosition = spawns[Random.Range(0, spawnPoints.Length - 1)];
        _lastSpawn = randomPosition;
        
        GameObject obstacle = Lean.Pool.LeanPool.Spawn(obstaclePrefab, spawnPoints[randomPosition].position, Quaternion.identity);
    }

    private void DestroyObstacle(GameObject obstacle)
    {
        Lean.Pool.LeanPool.Despawn(obstacle);
    }

}
