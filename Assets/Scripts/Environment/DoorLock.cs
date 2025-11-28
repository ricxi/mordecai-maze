using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private PlayerUIHandler playerUI;
    [SerializeField] private GameObject unlockedDoorPrefab;

    void Start()
    {
        if (playerUI == null)
            Debug.LogError("Missing PlayerUIManager reference");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                if (!playerInventory.HasSecretKey)
                {
                    playerUI.DisplayHintText("Looks like a key is needed to unlock this door.");
                }
                else
                {
                    playerInventory.UseSecretKey();
                    Instantiate(unlockedDoorPrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }

            }
        }
    }
}
