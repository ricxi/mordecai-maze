using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundHintCollider : MonoBehaviour
{
    [SerializeField] private SoundMisdirectMixer mixer;
    [SerializeField] private float defaultVolume;

    private void Start()
    {
        if (mixer == null) Debug.LogError("Reference to SoundMisdirectMixer is missing");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mixer.SetVolumeTo(defaultVolume);
            mixer.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float boxColliderRightEdge = GetComponent<BoxCollider2D>().bounds.max.x;
            float playerPositionX = collision.bounds.center.x;
            if (!(playerPositionX > boxColliderRightEdge))
            {
                mixer.Stop(); // I only want the sound to if the player exits left. I should test this a bit more rigorously
            }
        }
    }
}
