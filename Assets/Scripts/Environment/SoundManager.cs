using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource audioSource; // Audio Source for constantly playing sfx: e.g.: Bell Hint Audio Source
    [SerializeField] private AudioSource audioSourceOneShot; // Audio Source for one shot sounds
    [SerializeField] private float defaultVolume = 0.05f;
    [SerializeField] private float defaultVolumeOneShot = 0.1f;

    private bool _isOneShotLocked = false;
    private Coroutine _oneShotCooldownCoHandler = null;

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
        if (audioSource == null || audioSourceOneShot == null)
        {
            AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
            if (audioSources.Length > 2)
            {
                Debug.LogWarning("SoundManager expected two child audio sources, but received " + audioSources.Length);
                return;
            }

            audioSource = audioSources[0];
            audioSourceOneShot = audioSources[1];
        }

        audioSource.volume = defaultVolume;
        audioSourceOneShot.volume = defaultVolumeOneShot;
        if (!audioSource.loop) audioSource.loop = true;
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

    public void PlayOneShot(AudioClip audioClip)
    {
        if (_isOneShotLocked) return;
        audioSourceOneShot.PlayOneShot(audioClip);

        if (_oneShotCooldownCoHandler != null)
        {
            StopCoroutine(_oneShotCooldownCoHandler);
            _oneShotCooldownCoHandler = null;
        }
        _oneShotCooldownCoHandler = StartCoroutine(OneShotCooldown(audioClip.length));
    }

    private IEnumerator OneShotCooldown(float duration)
    {
        _isOneShotLocked = true;
        yield return new WaitForSecondsRealtime(duration);
        _isOneShotLocked = false;
    }
}
