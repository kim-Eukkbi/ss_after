using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public List<GameObject> helpImage; 
    public GameObject helpBase = null;
    public GameObject rightArrow = null;
    public GameObject leftArrow = null;
    public GameObject exit = null;
    public GameObject background = null;
    public GameInfo gameInfo = new GameInfo();

    private int i = 0;


    public void OpenHelp()
    {
        helpBase.SetActive(true);
        helpImage[0].SetActive(true);
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        exit.SetActive(true);
        background.SetActive(true);
    }

    public void LeftArrow()
    {
        if (helpImage[i].activeInHierarchy)
        {
            if (i == 0)
            {
                OffAll();
                return;
            }
            helpImage[i].SetActive(false);
            helpImage[i-1].SetActive(true);
            i--;
           
        }
    }
    public void RightArrow()
    {
        if(helpImage[i].activeInHierarchy)
        {
            if (i == 4)
            {
                OffAll();
                return;
            }
            helpImage[i].SetActive(false);
            helpImage[i+1].SetActive(true);
            i++;
        }
    }

    public void OffAll()
    {
        helpBase.SetActive(false);
        helpImage[i].SetActive(false);
        i = 0;
        OffEct();
    }

    private void OffEct()
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        exit.SetActive(false);
        background.SetActive(false);
    }
}
