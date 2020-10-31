using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gostcome : MonoBehaviour
{
    public List<GostScript> gosts; // 모든 커신 정보
    private List<GostScript> possibleGosts = new List<GostScript>(); // 아이템에 나올 수 있는 커신 정보
    private ItemLocation currentLocation = null; // for문에서 사용하는 현재 위치 정보

    private int gost_Come_idx = 0; // 커신 랜덤 인덱스

    [SerializeField]
    private float maxTimer = 10f;

    private void FixedUpdate()
    {
        if (GameManager.instance.locatedItem <= 0)
        {
            return;
        }

        for (int i = 0; i < GameManager.instance.itemLocation.Count; i++)
        {
            currentLocation = GameManager.instance.itemLocation[i];

            if (currentLocation.comeon_Gost == null && !currentLocation.is_wisp_inArea)
            {
                if (currentLocation.currentItem != null)
                {
                    if (currentLocation.timer >= maxTimer)
                    {
                        currentLocation.timer = 0f;

                        GostRandomCome(currentLocation);
                    }

                    else
                    {
                        currentLocation.timer++;
                    }
                }
            }
        }
    }

    private int RandomMake(List<GostScript> gostScripts)
    {
        float total = 0f;

        foreach (GostScript gostScript in gostScripts)
        {
            total += gostScript.gostInfo.gostComePersent;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < gostScripts.Count; i++)
        {
            if (randomPoint < gostScripts[i].gostInfo.gostComePersent)
            {
                return i;
            }
            else
            {
                randomPoint -= gostScripts[i].gostInfo.gostComePersent;
            }
        }

        return gostScripts.Count - 1;
    }

    private void GostRandomCome(ItemLocation itemLocation)
    {
        int rand = Random.Range(0, 100);
        
        if (rand < 80)
        {
            //Debug.Log("응 못와");
            return;
        }

        foreach (GostScript gost in gosts)
        {
            //Debug.Log("오고싶어하는 커신 : " + gost.gostInfo.gostName);

            if (itemLocation.currentItem.itemPart.Equals(gost.gostInfo.favorite_item))
            {
                //Debug.Log("출현 가능한 아이템임니다");

                if (!gost.gostInfo.Is_Gost_Come)
                {
                    possibleGosts.Add(gost);
                }
                else
                    //Debug.Log("하지만 이미 나왔어요");

                continue;
            }

            string[] types = gost.gostInfo.Come_item.Split(',');

            foreach (string type in types)
            {
                if (itemLocation.currentItem.itemType.Equals(type))
                {
                    //Debug.Log("출현 가능한 아이템임니다");

                    if (!gost.gostInfo.Is_Gost_Come)
                    {
                        possibleGosts.Add(gost);
                    }
                    else
                        //Debug.Log("하지만 이미 나왔어요");

                    break;
                }
            }
        }

        if (possibleGosts.Count == 0)
        {
            return;
        }

        possibleGosts.Sort((GostScript A, GostScript B) =>
        { return A.gostInfo.gostComePersent.CompareTo(B.gostInfo.gostComePersent); }); // 정렬해주는거임

        gost_Come_idx = RandomMake(possibleGosts);

        possibleGosts[gost_Come_idx].gostInfo.Is_Gost_Come = true;
        possibleGosts[gost_Come_idx].gostInfo.currentLocation = itemLocation;
        itemLocation.comeon_Gost = possibleGosts[gost_Come_idx];
        itemLocation.comeon_Gost.transform.position = itemLocation.transform.position;
        itemLocation.comeon_Gost.gameObject.SetActive(true);

        possibleGosts.Clear();
    }
}
