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

    private void OnDestroy()
    {
        ClearAudioClips();
        // if (Instance == this) Instance = null;
    }

    void Start()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        audioSource.volume = defaultVolume;
    }

    public void Play(AudioClip audioClip)
    {
        if (audioClip == null) Debug.LogWarning("Missing or invalid AudioClip reference (cannot play)");
        else
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    public void Stop()
    {
        if (audioSource.clip == null) Debug.LogWarning("Attempting Stop: Missing or invalid AudioClip reference in AudioSource");

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void SetVolumeTo(float volume)
    {
        if (audioSource.clip == null) Debug.LogWarning("Attempting to set volume: (missing or invalid AudioClip reference)");
        audioSource.volume = volume;
    }

    public void ClearAudioClips()
    {
        audioSource.clip = null;
    }
}
