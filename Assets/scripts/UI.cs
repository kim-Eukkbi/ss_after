using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject menu_set = null;
    public GameObject Ectv_button = null;
    public GameObject countiune_but = null;
    public GameObject quit_but = null;
    public void OpenMenu()
    {
        if(menu_set.activeSelf)
        {
            menu_set.SetActive(false);
            Ectv_button.SetActive(true);
        }
        else
        {
            menu_set.SetActive(true);
            Ectv_button.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
