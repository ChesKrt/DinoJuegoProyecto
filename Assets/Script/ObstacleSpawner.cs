using NaughtyAttributes;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private ObstacleDetector detector;

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
        int randomPosition = Random.Range(0, spawnPoints.Length);
        GameObject obstacle = Lean.Pool.LeanPool.Spawn(obstaclePrefab, spawnPoints[randomPosition].position, Quaternion.identity);
    }

    private void DestroyObstacle(GameObject obstacle)
    {
        Lean.Pool.LeanPool.Despawn(obstacle);
    }

}
