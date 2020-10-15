using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLocation : MonoBehaviour
{
    public int locationPage; // 맵 정보
    public ItemInfo currentItem = null; // 현재 위치에 있는 아이템 정보
    public GameObject selectBtn; // 위치 선택 버튼 정보
    public GostScript comeon_Gost = null; // 현재 위치에 있는 커신 정보
    public float timer = 0f; // 위치 쿨타임
    public bool is_wisp_inArea;

    [HideInInspector]
    public GameObject itemImage; // 현재 위치에 띄워줄 아이템 이미지

    private void Awake()
    {
        itemImage = transform.GetChild(0).gameObject;
    }
}
