using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource audioSource; // Bell Hint Audio Source
    [SerializeField] private float defaultVolume = 0.05f;

    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    // private void OnDestroy()
    // {
    //     if (Instance == this) Instance = null;
    // }

    void Start()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        audioSource.volume = defaultVolume;
    }

    public void PlayFirst(float volume)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = volume;
            Play();
        }
    }

    public void Play()
    {
        if (!audioSource.isPlaying) audioSource.Play();
    }

    public void Stop()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void SetVolumeTo(float volume)
    {
        audioSource.volume = volume;
    }
}
