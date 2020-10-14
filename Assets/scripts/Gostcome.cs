using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gostcome : MonoBehaviour
{
    public List<GostScript> gosts;
    private List<GostScript> possibleGosts = new List<GostScript>();

    private int gost_Come_idx = 0;

    [SerializeField]
    private float maxTimer = 10f;
    private float timer = 0f;

    private void FixedUpdate()
    {
        if (GameManager.instance.locatedItem <= 0)
            return;

        if (timer >= maxTimer)
        {
            timer = 0f;

            for (int i = 0; i < GameManager.instance.itemLocation.Count; i++)
            {
                if (GameManager.instance.itemLocation[i].comeon_Gost == null)
                {
                    if (GameManager.instance.itemLocation[i].currentItem != null)
                    {
                        GostRandomCome(GameManager.instance.itemLocation[i]);
                    }
                }
            }
        }
        else
        {
            timer++;
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

        gostScripts.Sort((GostScript A, GostScript B) => { return A.gostInfo.gostComePersent.CompareTo(B.gostInfo.gostComePersent); }); // 그냥 정렬해주는거임

        for (int i = 0; i < gostScripts.Count; i++)
        {
            if (randomPoint < gostScripts[i].gostInfo.gostComePersent)
            {
                /*
                if (gostScripts[i].gostInfo.Is_Gost_Come) // 랜덤으로 선택된 커신이 이미 나온 상태일때
                {
                    int is_All_Gost_Come = 0;
                    for (int j = 0; j < gostScripts.Count; j++)
                    {
                        if (gostScripts[j].gostInfo.Is_Gost_Come)
                            is_All_Gost_Come += 1;
                    }

                    if (is_All_Gost_Come >= gostScripts.Count)  // 가능한 모든 커신이 나온 상태일때
                    {
                        Debug.Log("더이상 나올 커신이 없슴니다!!!");
                        return 9999;
                    }
                    else
                        return RandomMake(gostScripts); // 다시 랜덤해
                }
                */

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
        foreach (GostScript gost in gosts)
        {
            Debug.Log("오고싶어하는 커신 : " + gost.gostInfo.gostName);
            string[] types = gost.gostInfo.Come_item.Split(',');

            foreach (string type in types)
            {
                if (itemLocation.currentItem.itemType.Equals(type))
                {
                    Debug.Log("출현 가능한 아이템임니다");

                    if (!gost.gostInfo.Is_Gost_Come)
                    {
                        possibleGosts.Add(gost);
                    }
                    else
                        Debug.Log("하지만 이미 나왔어요");

                    break;
                }
            }
        }

        if (possibleGosts.Count == 0)
        {
            return;
        }

        gost_Come_idx = RandomMake(possibleGosts);

        possibleGosts[gost_Come_idx].gostInfo.Is_Gost_Come = true;
        possibleGosts[gost_Come_idx].gostInfo.currentLocation = itemLocation;
        itemLocation.comeon_Gost = possibleGosts[gost_Come_idx];
        itemLocation.comeon_Gost.transform.position = itemLocation.transform.position;
        itemLocation.comeon_Gost.gameObject.SetActive(true);

        possibleGosts.Clear();
    }
}
