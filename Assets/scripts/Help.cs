using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public List<GameObject> helpImage; 
    public GameObject helpBase = null;
    public GameObject rightArrow = null;
    public GameObject leftArrow = null;
    public GameInfo gameInfo = new GameInfo();

    private int i = 0;


    public void OpenHelp()
    {
        helpBase.SetActive(true);
        helpImage[0].SetActive(true);
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
    }

    public void LeftArrow()
    {
        if (helpImage[i].activeInHierarchy)
        {
            if (i == 0)
            {
                helpBase.SetActive(false);
                helpImage[i].SetActive(false);
                i = 0;
                OffArrow();
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
                helpBase.SetActive(false);
                helpImage[i].SetActive(false);
                i = 0;
                OffArrow();
                return;
            }
            helpImage[i].SetActive(false);
            helpImage[i+1].SetActive(true);
            i++;
        }
    }

    private void OffArrow()
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
    }
}
