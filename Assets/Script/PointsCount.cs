using Unity.VisualScripting;
using UnityEngine;

public class PointsCount : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>() != null)
        {
            GameManager.instance.score++;
        }
    }
}
