using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public bool isStart = false;
    public Image image;
    public float opacity = 0;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
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
                SceneManager.LoadScene("mian");
            }
        }
    }
}