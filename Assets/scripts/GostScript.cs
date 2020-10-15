using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostScript : MonoBehaviour
{
    public GostInfo gostInfo;

    void OnEnable()
    {
        Debug.Log("ㅎㅇ");
        Invoke("GostOut", 60f);
    }

    private void GostOut()
    {
        Invoke("ComeDelay", 60f);
        gameObject.SetActive(false);
        gostInfo.currentLocation.comeon_Gost = null;
        Debug.Log("나감");
    }

    private void ComeDelay()
    {
        gostInfo.Is_Gost_Come = false;
    }
}

[System.Serializable]
public class GostInfo
{
    //[HideInInspector]
    public bool Is_Gost_Come = false;

    public ItemLocation currentLocation; // 현재 위치

    public string gostName; // 이름
    public string Come_item; // 커신이 등장하는 아이템타입
    public string favorite_item; // 커신이 좋아하는 아이템
    public float gostComePersent; // 올 확률
    public GameManager.Rarity gostRarity; // 레어도
    public int gostFavorability; // 호감도
}
