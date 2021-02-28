using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantEasterEgg : MonoBehaviour
{
    public AudioSource aud;
    public GameObject plane;
    public GameObject elephant;
    public float posibility = 1/7f;

    private void Start()
    {
        float rand = Random.value;
        if (rand > posibility)
        {
            aud.Stop();
            plane.SetActive(false);
            elephant.SetActive(false);
        }
    }
}
