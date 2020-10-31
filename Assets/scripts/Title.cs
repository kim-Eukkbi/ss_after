using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    
    public Image image;
    public GameObject base_image;
    public GameObject title_base;
    public GameObject title_image;
    public float opacity = 0;

    private bool isStart = false;
    private bool rotatebool = false;

    public void touch()
    {
        title_base.SetActive(false);
        SceneManager.LoadScene("mian");
    }

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Application.targetFrameRate = 60;
       
    }

    private void Update()
    {
        if (isStart == false)
        {
            opacity = Mathf.Clamp(opacity + Time.deltaTime, opacity, 1.5f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, opacity);
            if (opacity == 1.5f)
            {
                isStart = true;
            }
        }
        else if (isStart == true)
        {
            opacity = Mathf.Clamp(opacity - Time.deltaTime, 0, opacity);
            image.color = new Color(image.color.r, image.color.g, image.color.b, opacity);
            if (opacity == 0)
            {
                base_image.SetActive(false);
                title_base.SetActive(true);
            }
        }

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