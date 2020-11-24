using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLocation : MonoBehaviour
{
    public int locationPage; // 맵 정보
    public int locationNum; // 장소 번호
    public ItemInfo currentItem = null; // 현재 위치에 있는 아이템 정보
    public GameObject selectBtn; // 위치 선택 버튼 정보
    public GameObject removeBtn; // 위치 삭제 버튼 정보
    public GostScript comeon_Gost = null; // 현재 위치에 있는 커신 정보
    public float timer = 0f; // 위치 쿨타임
    public GameObject gostWisp = null; // 현재 위치에 있는 도깨비불 정보
    public bool is_wisp_inArea; // 현재 위치에 도깨비불이 있는가?

    [HideInInspector]
    public GameObject itemImage; // 현재 위치에 띄워줄 아이템 이미지

    private void Awake()
    {
        itemImage = transform.GetChild(0).gameObject;
    }
}
