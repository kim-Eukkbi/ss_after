using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject settingPopup;
    private bool is_popUped = false;

    private void PopUp()
    {
        if (!is_popUped)
        {
            settingPopup.SetActive(true);
            is_popUped = true;
        }
    }

    public void OnClickSetting()
    {
        PopUp();
    }

    public void RemovePopUp()
    {
        settingPopup.SetActive(false);
        is_popUped = false;
    }
}
