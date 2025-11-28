using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHintAdjuster : MonoBehaviour
{
    [SerializeField] private SoundMisdirectMixer mixer;
    [SerializeField] private float volume = 0.05f;

    private void Start()
    {
        if (mixer == null) Debug.LogError("Reference to SoundMisdirectMixer is missing");
    }

    // This only seems to work if the player is moving
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mixer.SetVolumeTo(volume);
        }
    }
}
