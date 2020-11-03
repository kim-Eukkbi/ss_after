﻿using System.Collections;
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
    private string jsonData;
    private string path;

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
        FileInfo fi = new FileInfo(string.Concat(Application.persistentDataPath, "/", "gameData.txt"));

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
    }

    [ContextMenu("모두 초기화")]
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

    public void RefreshWispText() // 도깨비불 텍스트 재설정
    {
        wispText.text = string.Format(" : {0}", gameInfo.wisp);
    }

    // Json IO
    [ContextMenu("To Json Data")]
    void SaveGameDataToJson()
    {
        jsonData = JsonUtility.ToJson(gameInfo, true);
        path = string.Concat(Application.persistentDataPath, "/", "gameData.txt");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadGameDataFromJson()
    {
        path = string.Concat(Application.persistentDataPath, "/", "gameData.txt");
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
