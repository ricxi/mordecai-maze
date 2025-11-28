using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHintCanceller : MonoBehaviour
{
    [SerializeField] private float cancelAfterTime = 5f;
    private Coroutine cancelSoundHandle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (cancelSoundHandle != null)
            {
                StopCoroutine(cancelSoundHandle);
                cancelSoundHandle = null;
            }
            cancelSoundHandle = StartCoroutine(CancelSoundAfter(cancelAfterTime));
        }
    }

    private IEnumerator CancelSoundAfter(float delay)
    {

        yield return new WaitForSeconds(delay);
        SoundManager.Instance.Stop();
        LobbyGameManager.Instance.CancelBellSound();
    }
}
