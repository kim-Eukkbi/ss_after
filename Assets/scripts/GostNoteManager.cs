using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostNoteManager : MonoBehaviour
{
    public int currentPage = 0;
    public List<GostNoteInfo> gostNotes;

    public void GostNoteUnlock(GostScript currentGost)
    {
        foreach (GostNoteInfo gostNote in gostNotes)
        {
            if (gostNote.gostName.Equals(currentGost.gostInfo.gostName))
            {
                gostNote.gameObject.SetActive(true);
                gostNote.is_unlocked = true;
            }
        }
    }

    public void GoPageRight()
    {
        if(currentPage < gostNotes.Count - 1)
            currentPage += 1;
    }

    public void GoPageLeft()
    {
        if (currentPage > 0)
            currentPage -= 1;
    }
}
