using UnityEngine;
using UnityEngine.UI;

public class UI_Settings : UIWindow
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _creditButton;
    
    public override void Initialize()
    {
        base.Initialize();
        _closeButton.onClick.AddListener(() => Hide());
    }
}
