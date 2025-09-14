using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private Vector2 limitX = new Vector2(-5, 5f);


    /*void Update()
    {
        float newX = transform.position.x + _moveDirection * moveSpeed * Time.deltaTime;
        newX = Mathf.Clamp(newX, limitX.x, limitX.y);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }*/

    [Button]
    public void MoveLeft()
    {
        Move(limitX.x);
    }

    [Button]
    public void MoveRight()
    {
        Move(limitX.y);
    }

    public void Move(float delta)
    {
        float targetX = Mathf.Clamp(transform.position.x + delta, limitX.x, limitX.y);
        transform.DOMoveX(targetX, moveSpeed);
    }
}
