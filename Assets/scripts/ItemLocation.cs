using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLocation : MonoBehaviour
{
    public int locationPage;
    public ItemInfo currentItem = null;
    public GameObject selectBtn;
    public GostScript comeon_Gost = null;

    [HideInInspector]
    public GameObject itemImage;

    private void Awake()
    {
        itemImage = transform.GetChild(0).gameObject;
    }
}
