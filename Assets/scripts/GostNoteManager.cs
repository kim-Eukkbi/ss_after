using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GostNoteManager : MonoBehaviour
{
    public int currentPage = 0;
    public Text infoPage;

    public void RefreshGostNote()
    {
        infoPage.text = string.Format("{0}", currentPage + 1);
        GameManager.instance.gostNotes[currentPage].gameObject.SetActive(true);
        GostNoteInfoOff();

        if (GameManager.instance.gostNotes[currentPage].noteInfo.gostFavorability > 0)
        {
            GostNoteInfoOn();
            
            if(GameManager.instance.gostNotes[currentPage].noteInfo.gostFavorability > 2)
            {
                GameManager.instance.gostNotes[currentPage].info_isUnlock.SetActive(true);
            }
        }
    }

    public void Increase_GostFavorability(GostScript currentGost)
    {
        foreach (GostNoteInfo gostNote in GameManager.instance.gostNotes)
        {
            if (gostNote.noteInfo.gostName.Equals(currentGost.gostInfo.gostName) && !currentGost.gostInfo.is_clicked)
            {
                Debug.Log(currentGost.gostInfo.gostName + "의 호감도 1 증가");
                currentGost.gostInfo.is_clicked = true;
                gostNote.noteInfo.gostFavorability += 1;

                RefreshGostNote();
                GameManager.instance.SaveData();

                break;
            }
        }
    }

    public void GoPageRight()
    {
        if (currentPage < GameManager.instance.gostNotes.Count - 1)
        {
            GameManager.instance.gostNotes[currentPage].gameObject.SetActive(false);
            currentPage += 1;
            RefreshGostNote();
        }
    }

    public void GoPageLeft()
    {
        if (currentPage > 0)
        {
            GameManager.instance.gostNotes[currentPage].gameObject.SetActive(false);
            currentPage -= 1;
            RefreshGostNote();
        }
    }

    public void GostNoteInfoOff()
    {
        GameManager.instance.gostNotes[currentPage].infoName.SetActive(false);
        GameManager.instance.gostNotes[currentPage].infoDes.SetActive(false);
        GameManager.instance.gostNotes[currentPage].infoImage.SetActive(false);
        GameManager.instance.gostNotes[currentPage].info_isUnlock.SetActive(false);
    }

    public void GostNoteInfoOn()
    {
        GameManager.instance.gostNotes[currentPage].infoName.SetActive(true);
        GameManager.instance.gostNotes[currentPage].infoDes.SetActive(true);
        GameManager.instance.gostNotes[currentPage].infoImage.SetActive(true);
    }

}