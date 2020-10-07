using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ItemData itemData;

    // 아이템을 클릭할시
    public void OnClickItem(ItemInfo currentItem)
    {
        switch (currentItem.itemNum)
        {
            case 1:

                if (itemData.item1_isActive)
                {
                    Debug.Log("이미 구매한 아이템임다!!!");
                }
                else 
                {
                    Debug.Log("아이템 정보 : " + currentItem.itemDes);
                    itemData.item1_isActive = true;
                    Debug.Log("아이템 구매완료");
                }
                break;

            case 2:

                if (itemData.item2_isActive)
                {
                    Debug.Log("이미 구매한 아이템임다!!!");
                }
                else
                {
                    Debug.Log("아이템 정보 : " + currentItem.itemDes);
                    itemData.item2_isActive = true;
                    Debug.Log("아이템 구매완료");
                }
                break;

            case 3:

                if (itemData.item3_isActive)
                {
                    Debug.Log("이미 구매한 아이템임다!!!");
                }
                else
                {
                    Debug.Log("아이템 정보 : " + currentItem.itemDes);
                    itemData.item3_isActive = true;
                    Debug.Log("아이템 구매완료");
                }
                break;
        }
    }

    // Json IO
    [ContextMenu("To Json Data")]
    void SaveItemDataToJson()
    {
        string jsonData = JsonUtility.ToJson(itemData, true);
        string path = Path.Combine(Application.dataPath, "itemData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadItemDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "itemData.json");
        string jsonData = File.ReadAllText(path);
        itemData = JsonUtility.FromJson<ItemData>(jsonData);
    }
}

[System.Serializable]
public class ItemData
{
    public bool item1_isActive;
    public bool item2_isActive;
    public bool item3_isActive;
}
