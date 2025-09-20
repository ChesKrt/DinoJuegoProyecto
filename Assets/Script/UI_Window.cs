using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class UI_Window : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private string windowID;
    [SerializeField] private Canvas windowCanvas;
    [SerializeField] private CanvasGroup windowCanvasGroup;
    
    [Header("Options")]
    [SerializeField] private bool hideOnStart;
    [SerializeField] private float animationTime = 0.5f;
    [SerializeField] private Ease animationEaseShow;
    [SerializeField] private Ease animationEaseHide;
    
    public bool IsShowing { get; private set; } = false;
    public string WindowId => windowID;

    private void Start()
    {
        Initialize();
    }

    public virtual void Initialize()
    {
        if (hideOnStart) Hide(true);
    }
    
    [Button]
    public virtual void Show(bool instant = false)
    {
        if (IsShowing) return;
        windowCanvas.gameObject.SetActive(true);
        
        // windowCanvas.gameObject.SetActive(true);
        if (instant)
        {
            windowCanvasGroup.transform.DOScale(Vector3.one, 0f);
        }
        else
        {
            windowCanvasGroup.transform.DOScale(Vector3.one, animationTime).SetEase(animationEaseShow);
            IsShowing = true;
        }
    }

    [Button]
    public virtual void Hide(bool instant = false)
    {
        // windowCanvas.gameObject.SetActive(false);
        if (instant)
        {
            windowCanvasGroup.transform.DOScale(Vector3.zero, 0f);
        }
        else
        {
            windowCanvasGroup.transform.DOScale(Vector3.zero, animationTime).SetEase(animationEaseHide)
                .OnComplete(() => DisableCanvas());
        }
    }

    private void DisableCanvas()
    {
        windowCanvas.gameObject.SetActive(false);
        IsShowing = false;
    }
    
}
