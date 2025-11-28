using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHintCanceller : MonoBehaviour
{
    [SerializeField] private SoundMisdirectMixer mixer;
    [SerializeField] private float cancelDelayTime = 5f;
    private float timeInZone = 0f;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            timeInZone += Time.deltaTime;
            if (timeInZone >= cancelDelayTime)
            {
                mixer.Stop();
            }
        }
    }

}
