using NaughtyAttributes;
using UnityEngine;

public class UI_Inventory : UI_Window
{
    [Header("UI Inventory")]
    
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private GameObject content;
    
    [Button]
    private void InstantiateItem()
    {
        Instantiate(itemPrefab, content.transform);
    }
}
