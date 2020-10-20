﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ItemData itemData;
    public PopupInfo shopPopup;

    private UIManager uiManager;
    private bool is_popuped = false;
    private ItemInfo currentItem;

    private void Start()
    {
        uiManager = GetComponent<UIManager>();
    }

    // 아이템을 클릭할시
    public void OnClickItem(ItemInfo itemInfo)
    {
        currentItem = itemInfo;

        if (!is_popuped)
        {
            shopPopup.itemImage.sprite = itemInfo.itemImage;
            shopPopup.itemName.text = itemInfo.itemName;
            shopPopup.itemDes.text = string.Format("타입 : {0}\n{1}", itemInfo.itemType, itemInfo.itemDes);
            shopPopup.itemPrice.text = string.Format("가격 : {0}", itemInfo.itemPrice);
            shopPopup.buyButton.SetActive(false);
            shopPopup.useButton.SetActive(false);
            shopPopup.removeButton.SetActive(false);

            switch (itemInfo.itemNum)   // 현재 아이템의 번호
            {
                case 1:

                    if (itemData.item1_isActive)
                    {
                        shopPopup.itemPrice.text = "구매 완료";
                        if (itemInfo.is_Located)
                            shopPopup.removeButton.SetActive(true);
                        else
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
                        shopPopup.itemPrice.text = "구매 완료";

                        if (itemInfo.is_Located)
                            shopPopup.removeButton.SetActive(true);
                        else
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
                        shopPopup.itemPrice.text = "구매 완료";

                        if (itemInfo.is_Located)
                            shopPopup.removeButton.SetActive(true);
                        else
                            shopPopup.useButton.SetActive(true);
                    }
                    else
                    {
                        shopPopup.buyButton.SetActive(true);
                    }
                    break;

                case 4:

                    if (itemData.item4_isActive)
                    {
                        shopPopup.itemPrice.text = "구매 완료";

                        if (itemInfo.is_Located)
                            shopPopup.removeButton.SetActive(true);
                        else
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
        if (GameManager.instance.gameInfo.wisp >= currentItem.itemPrice)
        {
            GameManager.instance.gameInfo.wisp -= currentItem.itemPrice;
            GameManager.instance.RefreshWispText();

            if (currentItem.itemNum == 1)
                itemData.item1_isActive = true;
            else if (currentItem.itemNum == 2)
                itemData.item2_isActive = true;
            else if (currentItem.itemNum == 3)
                itemData.item3_isActive = true;
            else if (currentItem.itemNum == 4)
                itemData.item4_isActive = true;

            shopPopup.itemPrice.text = "구매 완료";
            shopPopup.buyButton.SetActive(false);
            shopPopup.useButton.SetActive(true);

            GameManager.instance.SaveData();
        }
        else
        {
            shopPopup.itemPrice.text = "돈이 부족합니다!";
        }
    }

    public void UseItem()
    {
        uiManager.UseItem();
        foreach (ItemLocation itmLoc in GameManager.instance.itemLocation)
        {
            if (itmLoc.currentItem != null)
            {
                itmLoc.selectBtn.SetActive(false);
            }
            else
            {
                itmLoc.selectBtn.SetActive(true);
            }
        }
    }

    public void RemoveItem()
    {
        if (currentItem.location.comeon_Gost != null)
        {
            shopPopup.itemPrice.text = "아이템에 커신이 붙어있어 회수할수 없습니다";
            return;
        }

        if (currentItem.location.is_wisp_inArea)
        {
            GameManager.instance.gameInfo.wisp += currentItem.location.gostWisp.GetComponent<WispInfo>().wispSize;
            GameManager.instance.RefreshWispText();
            GameManager.instance.SaveData();

            shopPopup.itemPrice.text = "도깨비불 + " + currentItem.location.gostWisp.GetComponent<WispInfo>().wispSize;
            PoolManager.instance.InsertQueue(currentItem.location.gostWisp, PoolManager.PoolType.WISP);
            currentItem.location.gostWisp = null;

            currentItem.location.is_wisp_inArea = false;
        }

        currentItem.location.currentItem = null;
        currentItem.location.timer = 0f;
        currentItem.location.itemImage.SetActive(false);
        currentItem.location = null;
        currentItem.is_Located = false;

        GameManager.instance.locatedItem -= 1;

        shopPopup.useButton.SetActive(true);
        shopPopup.removeButton.SetActive(false);
    }

    public void PutItemInLocation(ItemLocation clickedLocation)
    {
        clickedLocation.currentItem = currentItem;
        clickedLocation.itemImage.GetComponent<Image>().sprite = currentItem.itemImage;
        clickedLocation.itemImage.SetActive(true);

        GameManager.instance.locatedItem += 1;

        currentItem.location = clickedLocation;
        currentItem.is_Located = true;
        shopPopup.useButton.SetActive(false);
        shopPopup.removeButton.SetActive(true);
        UseItem();
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

    public void RemovePopup()
    {
        uiManager.is_Use_item = false;
        uiManager.LocationSelect.SetActive(false);
        shopPopup.gameObject.SetActive(false);
        is_popuped = false;
    }


    // Json IO
    [ContextMenu("To Json Data")]
    public void SaveItemDataToJson()
    {
        string jsonData = JsonUtility.ToJson(itemData, true);
        string path = Path.Combine(Application.persistentDataPath, "itemData.txt");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    public void LoadItemDataFromJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "itemData.txt");
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
    public bool item4_isActive;
}