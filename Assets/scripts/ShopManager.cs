using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ItemData itemData;
    public PopupInfo shopPopup;
    public int item_Count = 0;

    [SerializeField]
    private GameObject itemBox;

    private UIManager uiManager;
    private bool is_popUped = false;
    private ItemInfo currentItem;

    private string jsonData;
    private string path;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
        item_Count = itemBox.transform.childCount;
    }

    // 아이템을 클릭할시
    public void OnClickItem(ItemInfo itemInfo)
    {
        if (itemInfo.itemPrice.Equals(0))
        {
            return;
        }

        if (!is_popUped)
        {
            currentItem = itemInfo;

            shopPopup.itemImage.sprite = itemInfo.itemImage;
            shopPopup.itemName.text = itemInfo.itemName;
            shopPopup.itemDes.text = string.Format("타입 : {0}\n{1}", itemInfo.itemType, itemInfo.itemDes);
            shopPopup.itemPrice.text = string.Format("가격 : {0}", itemInfo.itemPrice);
            shopPopup.buyButton.SetActive(false);
            shopPopup.useButton.SetActive(false);
            shopPopup.removeButton.SetActive(false);
            if (itemData.item_isActive[currentItem.itemNum - 1])
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

            ShowAndRemovePopup();
        }
    }

    public void BuyItem()
    {
        if (GameManager.instance.gameInfo.wisp >= currentItem.itemPrice)
        {
            GameManager.instance.gameInfo.wisp -= currentItem.itemPrice;
            GameManager.instance.RefreshWispText();

            itemData.item_isActive[currentItem.itemNum - 1] = true;

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
        foreach (ItemLocation itmLoc in GameManager.instance.itemLocations)
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
            currentItem.location.gostWisp.transform.SetParent(PoolManager.instance.transform);
            PoolManager.instance.InsertQueue(currentItem.location.gostWisp, PoolManager.PoolType.WISP);
            currentItem.location.gostWisp = null;

            currentItem.location.is_wisp_inArea = false;
        }

        if (currentItem.itemType.Equals("촉매"))
        {
            GameManager.instance.comepersent -= currentItem.itemPersent;
        }

        itemData.itemLocationInfo[currentItem.itemNum - 1].locationPage = 0;
        itemData.itemLocationInfo[currentItem.itemNum - 1].locationNum = 0;
        GameManager.instance.SaveData();

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
        if (currentItem.itemType.Equals("촉매"))
        {
            GameManager.instance.comepersent += currentItem.itemPersent;
        }
        clickedLocation.currentItem = currentItem;
        clickedLocation.itemImage.GetComponent<Image>().sprite = currentItem.itemImage;
        clickedLocation.itemImage.SetActive(true);

        itemData.itemLocationInfo[currentItem.itemNum - 1].locationPage = clickedLocation.locationPage;
        itemData.itemLocationInfo[currentItem.itemNum - 1].locationNum = clickedLocation.locationNum;

        GameManager.instance.SaveData();

        GameManager.instance.locatedItem += 1;

        currentItem.location = clickedLocation;
        currentItem.is_Located = true;
        shopPopup.useButton.SetActive(false);
        shopPopup.removeButton.SetActive(true);
        UseItem();
    }

    public void PutItemInLocation(ItemLocation clickedLocation, ItemInfo itemInfo)
    {
        if (itemInfo.itemType.Equals("촉매"))
        {
            GameManager.instance.comepersent += itemInfo.itemPersent;
        }
        clickedLocation.currentItem = itemInfo;
        clickedLocation.itemImage.GetComponent<Image>().sprite = itemInfo.itemImage;
        clickedLocation.itemImage.SetActive(true);

        itemData.itemLocationInfo[itemInfo.itemNum - 1].locationPage = clickedLocation.locationPage;
        itemData.itemLocationInfo[itemInfo.itemNum - 1].locationNum = clickedLocation.locationNum;

        GameManager.instance.SaveData();

        GameManager.instance.locatedItem += 1;

        itemInfo.location = clickedLocation;
        itemInfo.is_Located = true;
    }

    public void ShowAndRemovePopup()
    {
        if (!is_popUped)
        {
            shopPopup.gameObject.SetActive(true);
            is_popUped = true;
        }
        else
        {
            shopPopup.gameObject.SetActive(false);
            is_popUped = false;
        }
    }

    public void RemovePopup()
    {
        uiManager.is_Use_item = false;
        uiManager.LocationSelect.SetActive(false);
        shopPopup.gameObject.SetActive(false);
        is_popUped = false;
    }


    // Json IO
    [ContextMenu("To Json Data")]
    public void SaveItemDataToJson()
    {
        jsonData = JsonUtility.ToJson(itemData, true);
        path = string.Concat(Application.persistentDataPath, "/", "itemData2.txt");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    public void LoadItemDataFromJson()
    {
        path = string.Concat(Application.persistentDataPath, "/", "itemData2.txt");
        jsonData = File.ReadAllText(path);
        itemData = JsonUtility.FromJson<ItemData>(jsonData);
    }
}

[System.Serializable]
public class ItemData
{
    public List<bool> item_isActive;
    public List<ItemLocationInfo> itemLocationInfo;
}

[System.Serializable]
public class ItemLocationInfo
{
    public int locationPage;
    public int locationNum;
}