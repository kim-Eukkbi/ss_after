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

    private void Update()
    {
       /* if(menu_base.transform.position.y > 70)
        {
            menu_base.SetActive(false);
        }
        else
        {
            menu_base.SetActive(true);
        }*/
    }
    public void OpenMenu()
    {
        if(menu_set.activeSelf)
        {
            menu_set.SetActive(false);
            Ectv_button.SetActive(true);
            menu_base.transform.DOMove(new Vector2(0, 7.2f), 0.5f);
            Invoke("Off_menu", 0.5f);
        }
        else
        {
            menu_base.SetActive(true);
            menu_set.SetActive(true);
            Ectv_button.SetActive(false);
            menu_base.transform.DOMove(new Vector2(0, 0.5f), 0.5f);
        }
    }

    public void OpenNote()
    {
        if(note_set.activeSelf)
        {
            note_set.transform.DOMoveX(5f,1f);
            note_set.transform.DORotate(new Vector3(0, 0, -20), 1);
            Invoke("Off_note", 1);
        }
        else
        {
            note_set.SetActive(true);
            note_set.transform.DOMoveX(2, 1);
            note_set.transform.DORotate(new Vector3(0,0,27),1);
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


    public void Quit()
    {
        Application.Quit();
    }
}
