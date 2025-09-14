using NaughtyAttributes;
using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private ObstacleDetector detector;

    private int _lastSpawn = 1;
    
    void Start()
    {
        detector.OnObstacleDetected.AddListener(OnObstacleDetected);
    }

    private void OnObstacleDetected(GameObject obstacle)
    {
        DestroyObstacle(obstacle);
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
