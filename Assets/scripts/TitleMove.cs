using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TitleMove : MonoBehaviour
{

    private bool rotatebool = false;
    private bool sizebool = false;
    private void Update()
    {
        if (rotatebool == false)
        {
            Rotate();
            rotatebool = true;
        }

        if (sizebool == false)
        {
            Size();
            sizebool = true;
        }
    }

    private void Size()
    {
        transform.DOScale(Random.Range(1.7f, 2.1f),1).OnComplete(RE_Size);
    }
    private void RE_Size()
    {
        transform.DOScale(Random.Range(1f, 1.7f), 1f).OnComplete(SizeBoolcheck);
    }
    private void Rotate()
    {
        transform.DORotate(new Vector3(0, 0, 15), 1.2f).OnComplete(RE_Rotate);
    }
    private void RE_Rotate()
    {
        transform.DORotate(new Vector3(0, 0, -25), 1.2f).OnComplete(RotateBoolcheck);
    }

    private void RotateBoolcheck()
    {
        rotatebool = false;
    } 
    private void SizeBoolcheck()
    {
        sizebool = false;
    }
}
