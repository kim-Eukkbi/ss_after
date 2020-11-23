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
    public GameObject quit_popup = null;
    public GameObject note_set = null;
    public GameObject shop_base = null;
    public GameObject gostInfo_base = null;
    public GameObject setting_base = null;

    public GameObject LocationSelect;
    public GameObject DelLocationSelect;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menu_set.activeInHierarchy)
            {
                menu_set.SetActive(false);
                menu_base.transform.DOMoveX(4f, 0.5f).OnComplete(Ectv_Active_true_with_Off_Menu);
                Ectv_button.SetActive(true);
                return;
            }
            if (note_set.activeInHierarchy)
            {
                if(quit_popup.activeInHierarchy)
                {
                    quit_popup.SetActive(false);
                    return;
                }
                note_set.transform.DOMoveX(5f, 1f);
                note_set.transform.DORotate(new Vector3(0, 0, -2), 1).OnComplete(Ectv_Active_true_with_Off_Menu);
                Ectv_button.SetActive(true);
            }
            else
            {

                if(quit_popup.activeInHierarchy)
                    quit_popup.SetActive(false);
                else if(!quit_popup.activeInHierarchy)
                    quit_popup.SetActive(true);
                else
                    return;
            }
        }
    }
    // -------------------------------------ectv
    private void Ectv_Active_true()
    {
        is_Ectv_pressed = true;
    }
    private void Ectv_Active_true_with_Off_Menu()
    {
        is_Ectv_pressed = true;
        menu_base.SetActive(false);
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
    // -------------------------------------메뉴
    public void OpenMenu()  // 메뉴를 키고 끌 때 (컨티뉴, ECTV)
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
                menu_base.transform.DOMoveX(2f, 0.5f).OnComplete(All_NoteUse_Menu_Off);
                Ectv_button.SetActive(false);
            }
        }
    }

    public void OffMenuWithNote()   // 노트를 킬때 메뉴를 끔
    {
        is_Ectv_pressed = false;

        menu_set.SetActive(false);
        menu_base.transform.DOMoveX(4f, 0.5f).OnComplete(Ectv_Active_true_with_Off_Menu);
    }

    // -------------------------------------노트
    public void OffNote()   // 모든 노트를 닫을 때
    {
        if (note_set.activeInHierarchy)
        {
            note_set.transform.DOMoveX(5f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, -2), 1).OnComplete(All_NoteUse_Menu_Off_With_Ectv_off);
        }
    }

    private void OpenNoteWithMenu()   // 메뉴로 노트를 열 때
    {
        note_set.SetActive(true);
        note_set.transform.DOMoveX(0.1f, 1f);
        note_set.transform.DORotate(new Vector3(0, 0, 10), 1);
    }

    public void UseItem()   // 아이템 사용 (Shop에서)
    {
        if (!is_Use_item)
        {
            is_Use_item = true;
            LocationSelect.SetActive(true);
            note_set.transform.DOMoveX(5f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, -2), 1);
        }
        else
        {
            is_Use_item = false;
            LocationSelect.SetActive(false);
            note_set.SetActive(true);
            shop_base.SetActive(true);
            note_set.transform.DOMoveX(0.1f, 1f);
            note_set.transform.DORotate(new Vector3(0, 0, 10), 1);
        }
    }

    private void All_NoteUse_Menu_Off_With_Ectv_off()
    {
        note_set.SetActive(false);
        shop_base.SetActive(false);
        gostInfo_base.SetActive(false);
        setting_base.SetActive(false);
        Ectv_off();
    } 
    private void All_NoteUse_Menu_Off()
    {
        note_set.SetActive(false);
        shop_base.SetActive(false);
        gostInfo_base.SetActive(false);
        setting_base.SetActive(false);
    }


    public void Quit_popup()
    {
        quit_popup.SetActive(true);
    }

    public void Quit_popup_Off()
    {
        quit_popup.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    // --------------------------------------노트 ON/Off
    public void OpenGostInfo()
    {
        gostInfo_base.SetActive(true);
        OpenNoteWithMenu();
    }

    public void OpenShop()
    {
        shop_base.SetActive(true);
        OpenNoteWithMenu();
    }

    public void OpenSetting()
    {
        setting_base.SetActive(true);
        OpenNoteWithMenu();
    }

    public void OpenRewardAdPopup()
    {
        // 리워드 팝업 만들기
    }
}