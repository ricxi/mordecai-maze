using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInventory playerInventory = collision.gameObject.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddSecretKey();
                Destroy(gameObject);
            }
        }
    }
}
