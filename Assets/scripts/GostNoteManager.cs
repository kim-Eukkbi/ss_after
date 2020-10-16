using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostNoteManager : MonoBehaviour
{
    public int currentPage;
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
}
