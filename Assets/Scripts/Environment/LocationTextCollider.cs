using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTextCollider : MonoBehaviour
{
    enum TriggerPosition
    {
        Top = 0,
        Right = 1,
        Bottom = 2,
        Left = 3
    }

    [SerializeField] private PlayerUIHandler playerUI;
    [SerializeField] private string currentLocationName;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private TriggerPosition triggerEdgePosition;

    // There should be a cooldown so the location text doesn't keep spawning every time the player touches the collider
    private void Start()
    {
        if (playerUI == null) Debug.LogError("Missing PlayerUIManager reference");
        if (boxCollider == null) boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 playerCenterPos = collision.bounds.center;

            if (Trigger2DFromEdge(playerCenterPos))
            {
                StartCoroutine(playerUI.DisplayLocationText(currentLocationName));
            }
        }
    }
    private bool Trigger2DFromEdge(Vector3 playerCenterPos)
    {
        float playerAxis;
        float triggerEdge;
        switch (triggerEdgePosition)
        {
            case TriggerPosition.Top:
                playerAxis = playerCenterPos.y;
                triggerEdge = boxCollider.bounds.max.y;
                return playerAxis < triggerEdge;

            case TriggerPosition.Bottom:
                playerAxis = playerCenterPos.y;
                triggerEdge = boxCollider.bounds.min.y;
                return playerAxis > triggerEdge;

            case TriggerPosition.Right:
                playerAxis = playerCenterPos.x;
                triggerEdge = boxCollider.bounds.max.x;
                return playerAxis < triggerEdge;

            case TriggerPosition.Left:
                playerAxis = playerCenterPos.x;
                triggerEdge = boxCollider.bounds.min.x;
                return playerAxis > triggerEdge;
            default:
                return false;
        }
    }

}
