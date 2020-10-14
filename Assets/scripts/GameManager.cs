using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameInfo gameInfo;
    public Text wispText;

    public enum Rarity
    {
        COMMON,
        RARE
    }

    private void Awake()
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

    private void Start()
    {
        LoadGameDataFromJson();
        RefreshWispText();
    }

    public void RefreshWispText()
    {
        wispText.text = string.Format("도깨비불 : {0}", gameInfo.wisp);
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
    public List<ItemLocation> itemLocation;
    public long wisp;
}
