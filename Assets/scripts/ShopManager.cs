using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ItemData itemData;
    public PopupInfo shopPopup;

    private bool is_popuped = false;
    private ItemInfo currentItem;

    // 아이템을 클릭할시
    public void OnClickItem(ItemInfo itemInfo)
    {
        currentItem = itemInfo;

        if (!is_popuped)
        {
            shopPopup.itemImage.sprite = itemInfo.itemImage;
            shopPopup.itemName.text = itemInfo.itemName;
            shopPopup.itemDes.text = itemInfo.itemDes;
            shopPopup.itemPrice.text = string.Format("가격 : {0}", itemInfo.itemPrice);
            shopPopup.buyButton.SetActive(false);
            shopPopup.useButton.SetActive(false);

            switch (itemInfo.itemNum)   // 현재 아이템의 번호
            {
                case 1:

                    if (itemData.item1_isActive)
                    {
                        shopPopup.useButton.SetActive(true);
                    }
                    else
                    {
                        shopPopup.buyButton.SetActive(true);
                    }
                    break;

                case 2:

                    if (itemData.item2_isActive)
                    {
                        shopPopup.useButton.SetActive(true);
                    }
                    else
                    {
                        shopPopup.buyButton.SetActive(true);
                    }
                    break;

                case 3:

                    if (itemData.item3_isActive)
                    {
                        shopPopup.useButton.SetActive(true);
                    }
                    else
                    {
                        shopPopup.buyButton.SetActive(true);
                    }
                    break;
            }

            ShowAndRemovePopup();
        }
    }

    public void BuyItem()
    {
        if (GameManager.instance.gameInfo.coin >= currentItem.itemPrice)
        {
            GameManager.instance.gameInfo.coin -= currentItem.itemPrice;

            if (currentItem.itemNum == 1)
                itemData.item1_isActive = true;
            else if (currentItem.itemNum == 2)
                itemData.item2_isActive = true;
            else if (currentItem.itemNum == 3)
                itemData.item3_isActive = true;

            shopPopup.buyButton.SetActive(false);
            shopPopup.useButton.SetActive(true);

            Debug.Log("구매완료");
            Debug.Log("현재 돈 : " + GameManager.instance.gameInfo.coin);
        }
        else
        {
            Debug.Log("돈이 부족합니다!!");
        }
    }

    public void ShowAndRemovePopup()
    {
        if (!is_popuped)
        {
            shopPopup.gameObject.SetActive(true);
            is_popuped = true;
        }
        else
        {
            shopPopup.gameObject.SetActive(false);
            is_popuped = false;
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