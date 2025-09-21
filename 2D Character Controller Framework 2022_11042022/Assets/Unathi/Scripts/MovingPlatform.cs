using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float rayLength = 0.2f;
    public LayerMask platformLayer;

    private Transform currentPlatform;

    void Update()
    {
        // Cast a ray straight down from the player’s position
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, platformLayer);

        if (hit.collider != null)
        {
            // If standing on a platform and not already parented
            if (currentPlatform == null)
            {
                currentPlatform = hit.collider.transform;
                transform.SetParent(currentPlatform);
            }
        }
        else
        {
            // If no platform detected, unparent
            if (currentPlatform != null)
            {
                transform.SetParent(null);
                currentPlatform = null;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Debug ray in scene view
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
    }
}
