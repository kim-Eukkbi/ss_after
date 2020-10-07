using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gostcome : MonoBehaviour
{
    
    public GameObject gost = null;
    private int gostcomper = 0;
    private bool gostchack = false;
    private bool gostonchack = false;

    // Start is called before the first frame update
    private void Start()
    {
        if(gostonchack == false)
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
        if (gostcomper <= 40 && gostcomper != 0)
        {
            if (gostchack == false)
            {
                gost.SetActive(true);
                Debug.Log("ㅎㅇ");
                gostchack = true;
            }
        }
    }

    private void Randommake()
    {
        gostcomper = Random.Range(0, 100);
        Debug.Log(gostcomper);
    }
    private void Gostrancom()
    {
        if (!(gostcomper <= 40 && gostcomper !=0))
        {
            Randommake();
            gostchack = false;
        }
    }
 
}
