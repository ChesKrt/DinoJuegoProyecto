using System.IO;
using NaughtyAttributes;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    private string pathToSaveFile;
    
    private string jsonString;
    void Start()
    {
        pathToSaveFile = Path.Combine(Application.persistentDataPath, "PlayerStats.json");
    }

    [Button]
    void CreateJson()
    {
        PlayerStats playerStats = new PlayerStats();
        jsonString = JsonUtility.ToJson(playerStats);
        
        File.WriteAllText(pathToSaveFile, jsonString);
        print(pathToSaveFile);
    }
}
