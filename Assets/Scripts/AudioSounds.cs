using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSounds : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip AcceptClick;
    public AudioClip DiacceptClick;
    public AudioClip WinSound;
    public AudioClip LooseSound;
    public AudioClip ReleaseSound;
    public AudioClip Release2Sound;
    public AudioClip WindupSound;
    public AudioClip EatSound;

    public void Click1()
    {
        audioSource.PlayOneShot(AcceptClick);
    }

    public void Click2()
    {
        audioSource.PlayOneShot(DiacceptClick);
    }

    public void Release()
    {
        audioSource.PlayOneShot(ReleaseSound);
    }
    
    public void Release2()
    {
        audioSource.PlayOneShot(Release2Sound);
    }

    public void Windup()
    {
        audioSource.PlayOneShot(WindupSound);
    }

    public void Loose()
    {
        audioSource.PlayOneShot(LooseSound);
    }

    public void Win()
    {
        audioSource.PlayOneShot(WinSound);
    }

    public void Eat()
    {
        audioSource.PlayOneShot(EatSound);
    }
}
