using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TouchTitle : MonoBehaviour
{

    public void touch()
    {
        SceneLoader.Instance.LoadScene("mian");
    }
    
}
