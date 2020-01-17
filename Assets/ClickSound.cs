using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClickSound : MonoBehaviour
{
    public AudioSource buttonSource;
    public AudioClip clicksound;
    public AudioClip hoversound;


    public void hoversoundPlay()
    {
        buttonSource.PlayOneShot(hoversound);
    }
    public void clicksoundPlay()
    {
        buttonSource.PlayOneShot(clicksound);
    }
}
