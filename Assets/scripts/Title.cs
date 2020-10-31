using DG.Tweening;
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

    private bool isSceneLoading;

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Application.targetFrameRate = 60;
    }
    private void Start()
    {
        image.color = new Color(255f, 255f, 255f, 0f);
        image.DOFade(1f, 2f).OnComplete(() => { SceneLoader.Instance.LoadScene("touchtitle"); });
    }
}