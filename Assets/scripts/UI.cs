using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI : MonoBehaviour
{

    [SerializeField]
    private GameObject menu_base = null;
    private bool is_Ectv_pressed = false;

    public GameObject menu_set = null;
    public GameObject Ectv_button = null;
    public GameObject countiune_but = null;
    public GameObject quit_but = null;
    public GameObject note_set = null;
    public GameObject shop_base = null;

    public void OpenMenu()
    {
        if (!is_Ectv_pressed)
        {
            is_Ectv_pressed = true;
            Invoke("Ectv_Active", 0.51f);

            if (menu_set.activeSelf)
            {
                Ectv_button.SetActive(true);
                menu_base.transform.DOMoveX(4f, 0.5f);
                menu_set.SetActive(false);
                Invoke("Off_menu", 0.5f);
            }
            else
            {
                menu_base.SetActive(true);
                menu_set.SetActive(true);
                menu_base.transform.DOMoveX(2.5f, 0.5f);
                Ectv_button.SetActive(false);
            }
        }
    }

    public void OpenNote()
    {
        if(note_set.activeSelf)
        { 
            note_set.transform.DOMoveX(5f,1f);
            note_set.transform.DORotate(new Vector3(0, 0, -2), 1);
            Invoke("Off_note", 1);
            Invoke("Ectv_off", 0.001f);
        }
        else
        {
            note_set.SetActive(true);
            note_set.transform.DOMoveX(0.5f, 1f);
            note_set.transform.DORotate(new Vector3(0,0,10),1);
            Invoke("Ectv_off", 0.001f);
        }
    }
    private void Off_menu()
    {
        menu_base.SetActive(false);
    }

    private void Off_note()
    {
        note_set.SetActive(false);
        shop_base.SetActive(false);
    }

    private void Ectv_Active()
    {
        is_Ectv_pressed = false;
    }

    private void Ectv_off()
    {
        if(!Ectv_button.activeSelf)
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
    public void OpenShop()
    {
        if (shop_base.activeSelf)
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
}
