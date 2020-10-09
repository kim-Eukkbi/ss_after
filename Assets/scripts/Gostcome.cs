using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gostcome : MonoBehaviour
{
    
    public GameObject gost = null;
    private int gostComPer = 0;
    private bool gostcheck = false;
    private bool gost_come_check = false;
    private bool gostON = false;
    [SerializeField]
    private float chackdly = 0f;

   
    private void Start()
    {
    }

    private void Update()
    {
        if (gost_come_check == false)
        {
            if (!gost.activeSelf)
            {
                gost_come_check = true;
                InvokeRepeating("Gostrancom", 10, chackdly); 
            }
        }

        if (gostComPer <= 40 && gostComPer != 0)
        {
            if (gostcheck == false)
            {
                gost.SetActive(true);
                Debug.Log("ㅎㅇ");
                gostcheck = true;
                gostON = true;
            }
        }

        if(gost.activeSelf)
        { 
            if(gostON == true)
            {
                Invoke("Gostout", 60);
                CancelInvoke("Gostrancom");
                gostON = false;
            }
        }
    }

    private void Gostout()
    {
        gost.SetActive(false);
        Debug.Log("나감");
        gost_come_check = false;
    }

    private void Randommake()
    {
        gostComPer = 0;
        gostComPer = Random.Range(0, 100);
        Debug.Log(gostComPer);
    }

    private void Gostrancom()
    {
        if (!(gostComPer <= 40 && gostComPer !=0))
        {
            Randommake();
            gostcheck = false;
        }
    }
 
}
