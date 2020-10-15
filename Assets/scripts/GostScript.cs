using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostScript : MonoBehaviour
{
    public GostInfo gostInfo;
    private long myWisp = 0;

    void OnEnable()
    {
        Debug.Log("ㅎㅇ");
        Invoke("GostOut", 60f);
    }

    private void GostOut()
    {
        Invoke("ComeDelay", 60f);
        gostInfo.currentLocation.gostWisp = PoolManager.instance.GetQueue(PoolManager.PoolType.WISP);
        gostInfo.currentLocation.gostWisp.transform.position = this.transform.position;
        if (this.gostInfo.gostRarity.Equals(GameManager.Rarity.COMMON))
        {
            myWisp = Random.Range(15, 30);
        }
        else if (this.gostInfo.gostRarity.Equals(GameManager.Rarity.RARE))
        {
            myWisp = Random.Range(20, 40);
        }
        gostInfo.currentLocation.gostWisp.GetComponent<WispInfo>().wispSize = myWisp; // 영혼의 무게 값
        gostInfo.currentLocation.is_wisp_inArea = true;
        gostInfo.currentLocation.comeon_Gost = null;
        gameObject.SetActive(false);
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
