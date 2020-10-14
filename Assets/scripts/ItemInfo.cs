using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    //[HideInInspector]
    public bool is_Located;
    //[HideInInspector]
    public ItemLocation location;

    public int itemNum;
    public Sprite itemImage;
    public string itemName;
    public string itemDes;
    public string itemType;
    public int itemPrice;
}
