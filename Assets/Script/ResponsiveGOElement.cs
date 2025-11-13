using NaughtyAttributes;
using UnityEngine;

public class ResponsiveGOElement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform transformResponsive;

    [Header("Mobile Settings")]
    [SerializeField] private Vector3 mobileAnchorMin = new Vector3(0f, 0f, 0f);
    [SerializeField] private Vector3 mobileAnchorMax = new Vector3(0f, 0f, 0f);

    [Header("Tablet Settings")]
    [SerializeField] private Vector3 tabletAnchorMin = new Vector3(0f, 0f, 0f);
    [SerializeField] private Vector3 tabletAnchorMax = new Vector3(0f, 0f, 0f);

    ResponsiveGOManager _responsiveManager;

    void Start()
    {
        _responsiveManager = ResponsiveGOManager.instance;
        _responsiveManager.OnScreenSizeChanged.AddListener(UpdateAnchors);
        UpdateAnchors();
    }

    public void UpdateAnchors()
    {
        if (_responsiveManager == null) return;

        if (_responsiveManager.CurrentDeviceType == DeviceType.Mobile)
        {
            SetMobileAnchors();
        }
        else if (_responsiveManager.CurrentDeviceType == DeviceType.Tablet)
        {
            SetTabletAnchors();
        }
    }

    private void SetTabletAnchors()
    {
        transformResponsive.localScale = tabletAnchorMin;
        transformResponsive.localScale = tabletAnchorMax;
    }

    private void SetMobileAnchors()
    {
        transformResponsive.localScale = mobileAnchorMin;
        transformResponsive.localScale = mobileAnchorMax;
    }

    [Button]
    private void SaveMobileAnchors()
    {
        Vector3 maxAnchors = transformResponsive.localScale;
        Vector3 minAnchors = transformResponsive.localScale;

        mobileAnchorMax = maxAnchors;
        mobileAnchorMin = minAnchors;
    }

    [Button]
    private void SaveTabletAnchors()
    {
        Vector3 maxAnchors = transformResponsive.localScale;
        Vector3 minAnchors = transformResponsive.localScale;

        tabletAnchorMax = maxAnchors;
        tabletAnchorMin = minAnchors;
    }
}
