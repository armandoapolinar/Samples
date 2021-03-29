using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [SerializeField] AudioClip nightClip;
    [SerializeField] AudioClip dayClip;
    [SerializeField] AudioSource audioSource;
    
    public void PlayNightSound()
    {
        audioSource.clip = nightClip;
        audioSource.Play();
    }

    public void PlayDaySound()
    {
        audioSource.clip = dayClip;
        audioSource.Play();
    }
}
