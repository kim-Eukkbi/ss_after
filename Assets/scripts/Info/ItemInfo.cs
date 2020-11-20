using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    //[HideInInspector]
    public bool is_Located; // 아이템이 설치되어있는가?
    //[HideInInspector]
    public ItemLocation location; // 아이템이 설치된 위치 정보

    public int itemNum; // 아이템 넘버
    public Sprite itemImage; // 아이템 이미지
    public string itemName; // 아이템 이름
    public string itemDes; // 아이템 설명
    public string itemType; // 아이템 타입
    public string itemPart; // 아이템 타입2
    public int itemPrice; // 아이템 가격
    public int itemPersent;
}
