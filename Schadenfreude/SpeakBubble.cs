using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakBubble : MonoBehaviour
{
   public Transform playerMouth;
    public Canvas canvas;
    public RectTransform speechBubbleUI;

    void Update()
    {
        if (playerMouth != null && canvas != null && speechBubbleUI != null)
        {
            // Convert player mouth position to screen space
            Vector2 screenPoint = Camera.main.ScreenToViewportPoint(playerMouth.position);

            // Set the speech bubble UI position to the screen point
            speechBubbleUI.position = screenPoint;
        }
        else
        {
            Debug.LogWarning("Player mouth transform, Canvas, or SpeechBubble UI not assigned!");
        }
    }
}
