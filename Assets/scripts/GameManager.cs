using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private ShopManager shopManager = null; // 상점매니저
    [SerializeField]
    private GostNoteManager gostNoteManager = null; // 커신노트매니저
    [SerializeField]
    private Help helpManager = null; // 도움말
    private string jsonData;
    private string path;

    public GameInfo gameInfo;
    public Text wispText;
    public int locatedItem = 0; // 모든 맵에 설치되어 있는 아이템 갯수
    public float comepersent = 10f;

    public List<ItemLocation> itemLocations; // 모든 위치 정보
    public List<ItemInfo> itemInfos; // 모든 아이템 정보
    public List<GostNoteInfo> gostNotes; // 모든 커신 노트의 정보

    public enum Rarity
    {
        COMMON,
        RARE
    }

    private void Awake() // 싱글톤
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

        // 위에 코드 안쳐도 게임 실행 전에(꼭 실행 전에!! 이거 중요함) 하이어락키 안에 게임매니져가서 게임매니져 컴포넌트에서
        // ... 세운것 같이 생긴 모양 누르고 아래 나오는 매뉴중에서 "모두 초기화" 눌러도 됨니다
        // 잣버그 났을 때 말고도 게임 진행상황 초기화하고 싶을때 사용하셈요
        gameInfo = new GameInfo();
        shopManager.itemData = new ItemData();
        shopManager.itemData.item_isActive = new List<bool>(new bool[shopManager.item_Count]);
        shopManager.itemData.itemLocationInfo = new List<ItemLocationInfo>(new ItemLocationInfo[shopManager.item_Count]);

        FileInfo fi = new FileInfo(string.Concat(Application.persistentDataPath, "/", "gameData2.txt"));

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
            helpManager.OpenHelp();
            gameInfo.is_new_game = false;


            SaveData();
        }

        RefreshWispText();
        gostNoteManager.RefreshGostNote();
    }

    public void LoadData() // 저장한 데이터 불러오기
    {
        LoadGameDataFromJson();
        shopManager.LoadItemDataFromJson();

        foreach (GostNoteInfo gostNote in gostNotes)
        {
            for (int i = 0; i < gameInfo.noteInfos.Length; i++)
            {
                if (gameInfo.noteInfos[i].gostName.Equals(gostNote.noteInfo.gostName))
                {
                    gostNote.noteInfo = gameInfo.noteInfos[i];

                    break;
                }
            }
        }

        while (shopManager.itemData.itemLocationInfo.Count < shopManager.item_Count)
        {
            shopManager.itemData.itemLocationInfo.Add(new ItemLocationInfo());
            shopManager.itemData.item_isActive.Add(new bool());
        }

        foreach (ItemLocation itemLocation in itemLocations)
        {
            for (int i = 0; i < shopManager.itemData.itemLocationInfo.Count; i++)
            {
                if (itemLocation.locationPage.Equals(shopManager.itemData.itemLocationInfo[i].locationPage)
                    && itemLocation.locationNum.Equals(shopManager.itemData.itemLocationInfo[i].locationNum)) 
                {
                    //Debug.Log("현재 위치와 아이템 정보가 일치함");
                    shopManager.PutItemInLocation(itemLocation, itemInfos[i]);
                    locatedItem++;
                }
            }
        }
    }

    public void SaveData() // 현재 데이터 저장하기
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

    [ContextMenu("모두 초기화")]
    public void ResetData()
    {
        FileInfo fi = new FileInfo(string.Concat(Application.persistentDataPath, "/", "gameData2.txt"));
        try
        {
            fi.Delete();
        }
        catch (IOException e)
        {
            Debug.Log(e.Message);
        }

        fi = new FileInfo(string.Concat(Application.persistentDataPath, "/", "itemData2.txt"));
        try
        {
            fi.Delete();
        }
        catch (IOException e)
        {
            Debug.Log(e.Message);
        }
    }

    public void RefreshWispText() // 도깨비불 텍스트 재설정
    {
        wispText.text = string.Format(" : {0}", gameInfo.wisp);
    }

    // Json IO
    [ContextMenu("To Json Data")]
    void SaveGameDataToJson()
    {
        jsonData = JsonUtility.ToJson(gameInfo, true);
        path = string.Concat(Application.persistentDataPath, "/", "gameData2.txt");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadGameDataFromJson()
    {
        path = string.Concat(Application.persistentDataPath, "/", "gameData2.txt");
        jsonData = File.ReadAllText(path);
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
