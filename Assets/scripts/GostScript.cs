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
        gameObject.SetActive(false);
        Debug.Log("나감");
    }
}

[System.Serializable]
public class GostInfo
{
    [HideInInspector]
    public bool Is_Gost_Out;

    public string gostName;
    public int gostComePersent;
    public GameManager.Rarity gostRarity;
    public int gostFavorability;
}
