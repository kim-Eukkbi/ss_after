using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GostNoteManager : MonoBehaviour
{
    public int currentPage = 0;

    public void RefreshGostNote()
    {
        if (GameManager.instance.gostNotes[currentPage].noteInfo.gostFavorability > 0)
        {
            GameManager.instance.gostNotes[currentPage].gameObject.SetActive(true);
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
        if(currentPage < GameManager.instance.gostNotes.Count - 1)
            currentPage += 1;
    }

    public void GoPageLeft()
    {
        if (currentPage > 0)
            currentPage -= 1;
    }
}