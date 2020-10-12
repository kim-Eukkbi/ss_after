using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI : MonoBehaviour
{

    [SerializeField]
    private GameObject menu_base = null;
    private bool is_Ectv_pressed = true;

    public GameObject menu_set = null;
    public GameObject Ectv_button = null;
    public GameObject countiune_but = null;
    public GameObject quit_but = null;
    public GameObject note_set = null;
    public GameObject shop_base = null;
    public GameObject gostInfo_base = null;
    public GameObject setting_base = null;
    public GameObject gost_han_base = null;

    private void Ectv_Active_true()
    {
        is_Ectv_pressed = true;
    }
    private void Ectv_Active_true_with_Off_Menu()
    {
        is_Ectv_pressed = true;
        menu_base.SetActive(false);
    }
    public void OpenMenu()
    {
        if (is_Ectv_pressed)
        {
            is_Ectv_pressed = false;

            if (menu_set.activeInHierarchy)
            {
                Ectv_button.SetActive(true);
                menu_set.SetActive(false);
                menu_base.transform.DOMoveX(4f, 0.5f).OnComplete(Ectv_Active_true_with_Off_Menu);
            }
            else
            {
                menu_base.SetActive(true);
                menu_set.SetActive(true);
                menu_base.transform.DOMoveX(2f, 0.5f).OnComplete(Ectv_Active_true);
                Ectv_button.SetActive(false);
            }
        }
    }

    public void OpenNote()
    {
        if (note_set.activeInHierarchy)
        {
            note_set.transform.DOMoveX(5f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, -2), 1).OnComplete(All_NoteUse_Menu_Off_With_Ectv_off);
            //Invoke("Ectv_off", 0.001f);
        }
        else
        {
            note_set.SetActive(true);
            note_set.transform.DOMoveX(0.5f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, 10), 1).OnComplete(Ectv_off);
            //Invoke("Ectv_off", 0.001f);
        }
    }

    public void Gostcheck()
    {
        gost_han_base.SetActive(true);
    }
 

    private void All_NoteUse_Menu_Off_With_Ectv_off()
    {
        note_set.SetActive(false);
        shop_base.SetActive(false);
        gostInfo_base.SetActive(false);
        setting_base.SetActive(false);
        Ectv_off();
    }




    private void Ectv_off()
    {
        if (!Ectv_button.activeInHierarchy)
        {
            Ectv_button.SetActive(true);
        }
        else
        {
            Ectv_button.SetActive(false);
        }
    }


    public void Quit()
    {
        Application.Quit();
    }

    // 혹시 충돌날까봐 윗줄에 안쓰고 아랫줄에 추가함요 나중에 위로 올려주시길 바람
    public void OpenGostInfo()
    {
        if (gostInfo_base.activeInHierarchy)
        {
            gostInfo_base.SetActive(false);
            OpenNote();
        }
        else
        {
            gostInfo_base.SetActive(true);
            OpenNote();
        }
    }

    public void OpenShop()
    {
        if (shop_base.activeInHierarchy)
        {
            shop_base.SetActive(false);
            OpenNote();
        }
        else
        {
            shop_base.SetActive(true);
            OpenNote();
        }
    }

    public void OpenSetting()
    {
        if(setting_base.activeInHierarchy)
        {
            setting_base.SetActive(false);
            OpenNote();
        }
        else
        {
            setting_base.SetActive(true);
            OpenNote();
        }
    }
}