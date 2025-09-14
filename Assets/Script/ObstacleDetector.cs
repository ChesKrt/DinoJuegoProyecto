using UnityEngine;
using UnityEngine.Events;

public class ObstacleDetector : MonoBehaviour
{

    public UnityEvent<GameObject> OnObstacleDetected = new UnityEvent<GameObject>();

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Obstacle>())
        {
            Debug.Log("Obstacle");
            OnObstacleDetected?.Invoke(collision.gameObject);
        }
    }

}
