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
    public AudioClip[] ReleaseSounds;
    public AudioClip[] WindupSound;
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
        int i = Random.Range(0, ReleaseSounds.Length);
        audioSource.PlayOneShot(ReleaseSounds[i]);
    }

    public void Windup()
    {
        int i = Random.Range(0, WindupSound.Length);
        audioSource.PlayOneShot(WindupSound[i]);
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
