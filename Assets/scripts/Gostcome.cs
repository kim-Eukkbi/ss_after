using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gostcome : MonoBehaviour
{
    public GameObject gost = null;
    private int gost_Come_Per = 0;

    [SerializeField]
    private float maxTimer = 10f;
    private float timer = 0f;

    private void FixedUpdate()
    {
        if (gost.activeSelf)
            return;

        if (timer >= maxTimer)
        {
            timer = 0f;
            GostRandomCome();
        }
        else
        {
            timer++;
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
