using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispInfo : MonoBehaviour
{
    public Sprite wispImage;
    public long wispSize;
    public ItemLocation currentLocation;

    public void OnClickWisp()
    {
        GameManager.instance.gameInfo.wisp += wispSize;
        GameManager.instance.RefreshWispText();
        GameManager.instance.SaveData();

        transform.SetParent(PoolManager.instance.transform);
        PoolManager.instance.InsertQueue(this.gameObject, PoolManager.PoolType.WISP);

        currentLocation.gostWisp = null;
        currentLocation.is_wisp_inArea = false;
    }
}
