using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHintAdjuster : MonoBehaviour
{
    [SerializeField] private float volume = 0.05f;

    private void Start()
    {
        if (SoundManager.Instance == null) Debug.LogError("Reference to global SoundManager is missing");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.Instance.SetVolumeTo(volume);
        }
    }
}
