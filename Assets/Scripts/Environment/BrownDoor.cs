using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownDoor : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClips audioClips;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerUIHandler playerUI;
    private bool _isLocked;
    private bool _showHelpMessage;

    void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (playerUI == null) Debug.LogError("Missing PlayerUIManager reference");

        _isLocked = true;
        _showHelpMessage = true;
    }

    public void Interact()
    {
        if (!_isLocked)
        {
            animator.SetBool("isOpen", true);
        }
        else
        {
            SoundManager.Instance.PlayOneShot(audioClips.LockedDoor);
            playerUI.DisplayHintText("The door appears to be locked.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_showHelpMessage)
            {
                playerUI.DisplayHintText("Press X to interact with the door.");
                _showHelpMessage = false;
            }
        }
    }
}
