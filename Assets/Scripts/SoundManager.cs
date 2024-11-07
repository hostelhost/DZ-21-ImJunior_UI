using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundSound;

    public void SetBackgroundVolume(float level)
    {
       _backgroundSound.volume = level;
    }
}
