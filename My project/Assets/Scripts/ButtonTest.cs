using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTest : MonoBehaviour
{
    //public TMP_Text text;
    public AudioClip UIClick;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickButton()
    {
        //text.text = "You clicked me!";
        audioSource.PlayOneShot(UIClick, 0.75f);
        Application.Quit();

    }
}
