using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private PlayerUIHandler playerUI;

    private bool hasSecretKey;
    public bool HasSecretKey => hasSecretKey;


    void Start()
    {
        if (playerUI == null)
            Debug.LogError("Missing PlayerUIManager reference");

        hasSecretKey = false;
    }

    public void AddSecretKey()
    {
        hasSecretKey = true;
        playerUI.DisplayHintText("You found a key.");
    }

    public void UseSecretKey()
    {
        if (hasSecretKey)
        {
            hasSecretKey = false;
            playerUI.DisplayHintText("Key was used to unlock the door.");
        }
    }
}
