using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catalyst : MonoBehaviour
{
    public Gostcome gostmanager = null;

    [SerializeField]
    private float catalystCount = 0f;

    public void UseCatalysts()
    {
        gostmanager.comepersent = 20f;
        catalystCount--;
    }
}
