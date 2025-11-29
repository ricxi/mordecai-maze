using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    [SerializeField] private string nextLevelName;
    [SerializeField] private float delayTime = 0.5f;
    private Coroutine delayLoadNextSceneCoHandler;
    private Coroutine playerFreezeCoHandler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerBMovement player = collision.gameObject.GetComponent<PlayerBMovement>();
            if (player != null)
            {
                if (playerFreezeCoHandler != null)
                {
                    StopCoroutine(playerFreezeCoHandler);
                    playerFreezeCoHandler = null;
                }
                playerFreezeCoHandler = StartCoroutine(player.Freeze(delayTime + 0.1f));

                if (delayLoadNextSceneCoHandler != null)
                {
                    StopCoroutine(delayLoadNextSceneCoHandler);
                    delayLoadNextSceneCoHandler = null;
                }
                delayLoadNextSceneCoHandler = StartCoroutine(DelayLoadNextScene());
            }

        }
    }

    private IEnumerator DelayLoadNextScene()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(nextLevelName);
    }

}
