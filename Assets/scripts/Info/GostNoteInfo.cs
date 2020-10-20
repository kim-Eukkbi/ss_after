using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GostNoteInfo : MonoBehaviour
{
    public NoteInfo noteInfo;
    public GameObject info_isUnlock;
    public GameObject infoImage;
    public GameObject infoName;
    public GameObject infoDes;
    public Text infoPage;
}

[System.Serializable]
public class NoteInfo
{
    public string gostName; // 이름
    public int gostFavorability; // 호감도
}