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
    [SerializeField]
    private GostNoteManager gostNoteManager;

    public GameInfo gameInfo;
    public Text wispText;
    public int locatedItem = 0; // 모든 맵에 설치되어 있는 아이템 정보

    public List<ItemLocation> itemLocation; // 모든 위치 정보
    public List<GostNoteInfo> gostNotes; // 모든 커신 노트의 정보

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
        //◇♠☞유니티 잣버그 났을때☜♠◇ --- ↓아래 코드 주석 풀고 실행하고 다시 주석 달아주셈요 ---
        //SaveData();

        FileInfo fi = new FileInfo(Path.Combine(Application.persistentDataPath, "gameData.json"));

        if (fi.Exists) 
        {
            LoadData();
        }
        else 
        {
            SaveData();
        }

        if (gameInfo.is_new_game)
        {
            gameInfo.is_new_game = false;

            //TODO : 튜토리얼
            //Debug.Log("튜토리얼임니다");

            SaveData();
        }

        RefreshWispText();
        gostNoteManager.RefreshGostNote();
    }

    public void LoadData()
    {
        LoadGameDataFromJson();
        shopManager.LoadItemDataFromJson();

        for (int i = 0; i < gostNotes.Count; i++)
        {
            gostNotes[i].noteInfo = gameInfo.noteInfos[i];
        }
    }

    public void SaveData()
    {
        List<NoteInfo> noteInfos = new List<NoteInfo>();
        foreach (GostNoteInfo gostNote in gostNotes)
        {
            noteInfos.Add(gostNote.noteInfo);
        }
        gameInfo.noteInfos = noteInfos.ToArray();

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
        string path = Path.Combine(Application.persistentDataPath, "gameData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadGameDataFromJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "gameData.json");
        string jsonData = File.ReadAllText(path);
        gameInfo = JsonUtility.FromJson<GameInfo>(jsonData);
    }
}

[System.Serializable]
public class GameInfo
{
    public long wisp = 200; // 재화
    public bool is_new_game = true;
    public NoteInfo[] noteInfos;
}
