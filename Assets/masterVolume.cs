using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterVolume : MonoBehaviour
{
    public void MasterVolume(float newVolume)
    {
        AudioListener.volume = newVolume;
    }
}
