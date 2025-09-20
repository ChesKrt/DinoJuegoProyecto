using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : UI_Window
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Button creditButton;
    
    public override void Initialize()
    {
        base.Initialize();
        closeButton.onClick.AddListener(() => Hide());
    }
}
