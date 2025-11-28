using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PhysicalHintCollider : MonoBehaviour
{
    [SerializeField] private PlayerUIHandler playerUI;
    [SerializeField] private string initialHint;
    [SerializeField] private string followupHint;
    [SerializeField] private string finalHint;
    [SerializeField] private int followupHintCountMax = 3;
    [SerializeField] private int finalHintCountMax = 10;

    private int hintCount;

    private void Start()
    {
        if (playerUI == null)
            Debug.LogError("Player UI must be referenced");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hintCount++;
            string hint;
            if (hintCount > finalHintCountMax)
            {
                hint = finalHint;
            }
            else if (hintCount > followupHintCountMax)
            {
                hint = followupHint;
            }
            else
            {
                hint = initialHint;
            }

            playerUI.DisplayHintText(hint);
        }
    }
}
