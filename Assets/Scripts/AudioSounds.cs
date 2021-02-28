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

    private int randomController(int oldNumber, int min, int max)
    {
        int a = Random.Range(0, 4);
        if (a == oldNumber)
        {
            return randomController(oldNumber, min, max);
        }
        return a;
    }

    public void Click1()
    {
        audioSource.PlayOneShot(AcceptClick);
    }

    public void Click2()
    {
        audioSource.PlayOneShot(DiacceptClick);
    }

    private int _lastRelease = -1;
    public void Release()
    {
        int i = randomController(_lastRelease, 0, ReleaseSounds.Length);
        audioSource.PlayOneShot(ReleaseSounds[i]);
        _lastRelease = i;
    }

    private int _lastWindup = -1;
    public void Windup()
    {
        int i = randomController(_lastWindup, 0, WindupSound.Length);
        audioSource.PlayOneShot(WindupSound[i]);
        _lastWindup = i;
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
