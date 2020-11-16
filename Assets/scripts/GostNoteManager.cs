using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GostNoteManager : MonoBehaviour
{
    public int currentPage = 0;
    public Text infoPage;

    private NoteInfo currentNote;

    public void RefreshGostNote()
    {
        infoPage.text = string.Format("{0}", currentPage + 1);
        GameManager.instance.gostNotes[currentPage].gameObject.SetActive(true);
        GostNoteInfoOff();

        currentNote = GameManager.instance.gostNotes[currentPage].noteInfo;

        if (currentNote.gostFavorability > 0)
        {
            GostNoteInfoOn(currentNote);
            
            if(currentNote.gostFavorability > 5)
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
        GameManager.instance.gostNotes[currentPage].infoImportant.SetActive(false);
        GameManager.instance.gostNotes[currentPage].infoDes1.SetActive(false);
        GameManager.instance.gostNotes[currentPage].infoDes2.SetActive(false);
        GameManager.instance.gostNotes[currentPage].infoDes3.SetActive(false);
        GameManager.instance.gostNotes[currentPage].infoImage.SetActive(false);
        GameManager.instance.gostNotes[currentPage].info_isUnlock.SetActive(false);
    }

    public void GostNoteInfoOn(NoteInfo noteInfo)
    {
        GameManager.instance.gostNotes[currentPage].infoImage.SetActive(true);

        if (noteInfo.gostFavorability > 0) // 이름 해금
        {
            GameManager.instance.gostNotes[currentPage].infoName.SetActive(true);
            if (noteInfo.gostFavorability > 1) // 중요정보 해금
            {
                GameManager.instance.gostNotes[currentPage].infoImportant.SetActive(true);
                if (noteInfo.gostFavorability > 2) // TMI 1 해금
                {
                    GameManager.instance.gostNotes[currentPage].infoDes1.SetActive(true);
                    if (noteInfo.gostFavorability > 3) // TMI 2 해금
                    {
                        GameManager.instance.gostNotes[currentPage].infoDes2.SetActive(true);
                        if (noteInfo.gostFavorability > 4) // TMI 3 해금
                        {
                            GameManager.instance.gostNotes[currentPage].infoDes3.SetActive(true);
                        }
                    }
                }
            }
        }
    }

}