using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Sprite muteSprite;
    [SerializeField]
    private Sprite nomalSprite;
    [SerializeField]
    private Image buttonImage;

    public AudioClip click;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.PlayOneShot(click);
    }

    private void Update()
    {
        if(audioSource.volume == 0)
        {
            buttonImage.sprite = muteSprite;
        }
    }

    public void SetVolume(float volume)
    {
        if(buttonImage.sprite == muteSprite)
        {
            buttonImage.sprite = nomalSprite;
        }
        audioSource.volume = volume;
    }

    public void MuteVolume()
    {
        audioSource.volume = 0;
        slider.value = 0;
    }
}
