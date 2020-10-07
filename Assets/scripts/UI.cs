using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI : MonoBehaviour
{

    [SerializeField]
    private GameObject menu_base = null;
    

    public GameObject menu_set = null;
    public GameObject Ectv_button = null;
    public GameObject countiune_but = null;
    public GameObject quit_but = null;
    public GameObject note_set = null;

    public void OpenMenu()
    {
        if(menu_set.activeSelf)
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
}
