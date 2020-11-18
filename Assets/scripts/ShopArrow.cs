using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopArrow : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> item = null;

    private int i = 0;

    public void LeftArrow()
    {
        if (i == 0)
        {
            return;
        }
        for (int j = 0; j < 8; j++)
        {
            item[j].SetActive(true);
            item[j+8].SetActive(false);
        }
        i--;
    }
    public void RightArrow()
    {
        if (i == 1)
        {
            return;
        }
        for (int j = 0; j < 8; j++)
        {
            item[j].SetActive(false);
            item[j + 8].SetActive(true);
        }
        i++;
    }
}
