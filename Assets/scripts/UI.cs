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
    public GameObject background = null;

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
        }
        else
        {
            menu_set.SetActive(true);
            Ectv_button.SetActive(false);
            menu_base.transform.DOMove(new Vector2(0, 0.5f), 0.5f);
        }
    }

  



    public void Quit()
    {
        Application.Quit();
    }
}
