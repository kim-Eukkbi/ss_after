using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostNoteInfo : MonoBehaviour
{
    public NoteInfo noteInfo;
}

[System.Serializable]
public class NoteInfo
{
    public string gostName; // 이름
    public int gostFavorability; // 호감도
}