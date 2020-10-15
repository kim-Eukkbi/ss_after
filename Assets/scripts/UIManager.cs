using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private GameObject menu_base = null;
    private bool is_Ectv_pressed = true;

    public bool is_Use_item = false;

    public GameObject menu_set = null;
    public GameObject Ectv_button = null;
    public GameObject countiune_but = null;
    public GameObject quit_but = null;

    public GameObject note_set = null;
    public GameObject shop_base = null;
    public GameObject gostInfo_base = null;
    public GameObject setting_base = null;
    public GameObject gost_han_base = null;

    public GameObject LocationSelect;

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

    public void OffMenuWithNote()
    {
        is_Ectv_pressed = false;

        menu_set.SetActive(false);
        menu_base.transform.DOMoveX(4f, 0.5f).OnComplete(Ectv_Active_true_with_Off_Menu);
    }

    public void OpenNote()
    {
        if (note_set.activeInHierarchy)
        {
            note_set.transform.DOMoveX(5f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, -2), 1).OnComplete(All_NoteUse_Menu_Off_With_Ectv_off);
        }
        else
        {
            note_set.SetActive(true);
            note_set.transform.DOMoveX(0.5f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, 10), 1).OnComplete(Ectv_off);
        }
    }

    public void OpenNoteWithMenu()
    {
        if (note_set.activeInHierarchy)
        {
            note_set.transform.DOMoveX(5f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, -2), 1).OnComplete(All_NoteUse_Menu_Off_With_Ectv_off);
        }
        else
        {
            note_set.SetActive(true);
            note_set.transform.DOMoveX(0.5f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, 10), 1);
        }
    }

    public void UseItem()
    {
        if (!is_Use_item)
        {
            is_Use_item = true;
            LocationSelect.SetActive(true);
            note_set.transform.DOMoveX(5f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, -2), 1);//.OnComplete(All_NoteUse_Menu_Off_UseItem);
        }
        else
        {
            is_Use_item = false;
            LocationSelect.SetActive(false);
            note_set.SetActive(true);
            shop_base.SetActive(true);
            note_set.transform.DOMoveX(0.5f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, 10), 1);
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

    private void All_NoteUse_Menu_Off_UseItem()
    {
        //LocationSelect.SetActive(true);
        //note_set.SetActive(false);
        //shop_base.SetActive(false);
        gostInfo_base.SetActive(false);
        setting_base.SetActive(false);
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

    // --------------------------------------노트 ON/Off
    public void OpenGostInfo()
    {
        if (gostInfo_base.activeInHierarchy)
        {
            gostInfo_base.SetActive(false);
            OpenNoteWithMenu();
        }
        else
        {
            gostInfo_base.SetActive(true);
            OpenNoteWithMenu();
        }
    }

    public void OpenShop()
    {
        if (shop_base.activeInHierarchy)
        {
            shop_base.SetActive(false);
            OpenNoteWithMenu();
        }
        else
        {
            shop_base.SetActive(true);
            OpenNoteWithMenu();
        }
    }

    public void OpenSetting()
    {
        if (setting_base.activeInHierarchy)
        {
            setting_base.SetActive(false);
            OpenNoteWithMenu();
        }
        else
        {
            setting_base.SetActive(true);
            OpenNoteWithMenu();
        }
    }
}