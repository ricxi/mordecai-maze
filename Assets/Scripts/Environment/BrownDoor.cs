using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrownDoor : MonoBehaviour, IInteractable
{
    [SerializeField] AudioClips audioClips;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isLocked;

    void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
        isLocked = true;
    }

    public void Interact()
    {
        if (!isLocked)
        {
            animator.SetBool("isOpen", true);
        }
        else
        {
            SoundManager.Instance.PlayOneShot(audioClips.LockedDoor);
        }
    }
}
