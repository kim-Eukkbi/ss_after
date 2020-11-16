using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catalyst : MonoBehaviour
{
    public Gostcome gostmanager = null;

    [SerializeField]
    private float catalystCount = 5f;
    [SerializeField]
    private float catalysTimer = 120;

    private float catalystOverCount = 0f;

    private void Update()
    {
        if (catalysTimer < 0)
        {
            catalystOverCount--;
            catalysTimer = 120;
            gostmanager.comepersent = 10f;
            return;
        }
        if(catalystCount < catalystOverCount)
        {
            catalysTimer -= Time.deltaTime;
        }
    }
    public void UseCatalysts()
    {
        if(catalysTimer != 0 && catalystCount < catalystOverCount)
        {
            return;
        }
        if(catalystCount < 1)
        {
            Debug.Log("촉매 부족");
            return;
        }
        catalystOverCount = catalystCount;
        gostmanager.comepersent = 20f;
        catalystCount--;
    }
}
