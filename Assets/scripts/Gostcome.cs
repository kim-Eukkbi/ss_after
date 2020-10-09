using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gostcome : MonoBehaviour
{
    public GameObject gost = null;
    private int gost_Come_Per = 0;
    private bool gost_Come_Check = false;

    [SerializeField]
    private float timer = 10f;

    private void FixedUpdate()
    {
        if (gost.activeSelf)
            return;

        if (gost_Come_Check == false)
        {
            if (!gost.activeSelf)
            {
                GostRandomCome();
            }
        }
    }

    private void RandomMake()
    {
        gost_Come_Per = 0;
        gost_Come_Per = Random.Range(0, 100);
        Debug.Log(gost_Come_Per);
    }

    private void GostRandomCome()
    {
        RandomMake();

        if (gost_Come_Per <= 40 && gost_Come_Per != 0)
        {
            gost.SetActive(true);
        }
    }
 
}
