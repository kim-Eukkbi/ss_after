using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gostcome : MonoBehaviour
{
    
    public GameObject gost = null;
    private int gostComPer = 0;
    private bool gostcheck = false;
    private bool gostoncheck = false;

    // Start is called before the first frame update
    private void Start()
    {
        if(gostoncheck == false)
        {
            if (!gost.activeSelf)
            {
                InvokeRepeating("Gostrancom", 1, 15);
            }
            else
            {
                CancelInvoke("Gostrancom");
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (gostComPer <= 40 && gostComPer != 0)
        {
            if (gostcheck == false)
            {
                gost.SetActive(true);
                Debug.Log("ㅎㅇ");
                gostcheck = true;
            }
        }
    }

    private void Randommake()
    {
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
