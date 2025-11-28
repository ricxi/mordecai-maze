using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundHintCollider : MonoBehaviour
{
    [SerializeField] private AudioClips audioClips;
    [SerializeField] private float volume;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        if (SoundManager.Instance == null) Debug.LogError("Reference to global SoundManager is missing");
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!LobbyGameManager.Instance.IsBellCancelled)
        {
            if (collision.CompareTag("Player"))
            {
                SoundManager.Instance.Play(audioClips.BellSound);
                SoundManager.Instance.SetVolumeTo(volume);
            }
        }
    }

    // Stops playing sound hint only if the player exits the left or top edge of the collider. 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float bcRightEdge = _boxCollider.bounds.max.x;
            float playerPositionX = collision.bounds.center.x;
            if (!(playerPositionX > bcRightEdge))
            {
                if (!LobbyGameManager.Instance.IsBellCancelled)
                {
                    SoundManager.Instance.Stop();
                }
                else
                {
                    LobbyGameManager.Instance.ResetInstance();
                }
            }
        }
    }
}
