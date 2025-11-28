using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMisdirectMixer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.05f;
    }

    public void Play()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            audioSource.Play();
        }
    }

    public void Stop()
    {
        if (isPlaying)
        {
            isPlaying = false;
            audioSource.Stop();
        }
    }

    // I'm getting inconsistent volume adjustments
    // I might have to look into audio mixer
    public void SetVolumeTo(float volume)
    {
        if (isPlaying)
        {
            audioSource.volume = volume;
        }
    }
}
