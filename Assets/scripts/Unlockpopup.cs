using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Unlockpopup : MonoBehaviour
{
    [SerializeField]
    private GameObject popup;
    [SerializeField]
    private Image popupImage;
    public void Off()
    {
        popup.SetActive(false);
    }

    public void On()
    {
        if(popupImage.sprite == null)
        {
            return;
        }
        popup.SetActive(true);
    }

}
