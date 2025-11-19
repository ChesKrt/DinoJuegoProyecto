using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class Obstacle : MonoBehaviour
{
    public float fallSpeed = 0.5f;
    
    private Transform initialTransform;

    void Start()
    {
        initialTransform = transform;
    }
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
    }

    void OnDisable()
    {
        transform.position = initialTransform.position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            GameManager.instance.GameFinished(true);
            AudioManager.instance.PlayClip(0);
            gameObject.SetActive(false);
        }
    }
}
