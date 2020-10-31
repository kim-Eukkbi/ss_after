using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TouchTitle : MonoBehaviour
{
    private bool rotatebool = false;
    public GameObject title_base;
    public GameObject title_image;


    public void touch()
    {
        SceneLoader.Instance.LoadScene("mian");
    }
    private void Update()
    {
        if (title_base.activeInHierarchy)
        {
            if (rotatebool == false)
            {
                Rotate();
                rotatebool = true;
            }

        }
    }
    private void Rotate()
    {
        title_image.transform.DORotate(new Vector3(0, 0, 15), 1.2f).OnComplete(RE_Rotate);
    }
    private void RE_Rotate()
    {
        title_image.transform.DORotate(new Vector3(0, 0, -15), 1.2f).OnComplete(RotateBoolcheck);
    }

    private void RotateBoolcheck()
    {
        rotatebool = false;
    }
}
