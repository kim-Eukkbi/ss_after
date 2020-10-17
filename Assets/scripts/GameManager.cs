using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private ShopManager shopManager = null;

    public GameInfo gameInfo;
    public Text wispText;
    public int locatedItem = 0; // 모든 맵에 설치되어 있는 아이템 정보

    public List<ItemLocation> itemLocation; // 모든 위치 정보

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
            //Debug.LogError("Error : instance is not null");
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        LoadData();

        RefreshWispText();
    }

    public void LoadData()
    {
        LoadGameDataFromJson();
        shopManager.LoadItemDataFromJson();

        if (gameInfo.is_new_game)
        {
            gameInfo.is_new_game = false;

            //TODO : 튜토리얼
            Debug.Log("튜토리얼임니다");

            SaveGameDataToJson();
            shopManager.SaveItemDataToJson();
        }
    }

    public void SaveData()
    {
        SaveGameDataToJson();
        shopManager.SaveItemDataToJson();
    }

    public void RefreshWispText()
    {
        wispText.text = string.Format(" : {0}", gameInfo.wisp);
    }

    // Json IO
    [ContextMenu("To Json Data")]
    void SaveGameDataToJson()
    {
        string jsonData = JsonUtility.ToJson(gameInfo, true);
        string path = Path.Combine(Application.dataPath, "gameData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadGameDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "gameData.json");
        string jsonData = File.ReadAllText(path);
        gameInfo = JsonUtility.FromJson<GameInfo>(jsonData);
    }
}

[System.Serializable]
public class GameInfo
{
    public long wisp = 200; // 재화
    public bool is_new_game = true;
}
