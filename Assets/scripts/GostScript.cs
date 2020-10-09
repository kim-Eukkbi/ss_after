using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostScript : MonoBehaviour
{
    void OnEnable()
    {
        Debug.Log("ㅎㅇ");
        Invoke("GostOut", 60f);
    }

    private void GostOut()
    {
        gameObject.SetActive(false);
        Debug.Log("나감");
        //gost_Come_Check = false;
    }
}
