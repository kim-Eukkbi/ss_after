using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameInfo gameInfo;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Error : instance is not null");
            Destroy(this.gameObject);
        }
    }

    // Json IO
    [ContextMenu("To Json Data")]
    public void SaveGameDataToJson()
    {
        string jsonData = JsonUtility.ToJson(gameInfo, true);
        string path = Path.Combine(Application.dataPath, "gameData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    public void LoadGameDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "gameData.json");
        string jsonData = File.ReadAllText(path);
        gameInfo = JsonUtility.FromJson<GameInfo>(jsonData);
    }
}

[System.Serializable]
public class GameInfo
{
    public int coin;
}
