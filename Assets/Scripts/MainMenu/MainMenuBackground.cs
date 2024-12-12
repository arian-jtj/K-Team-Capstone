using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackground : MonoBehaviour
{
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Set the anchors to stretch
        rectTransform.anchorMin = Vector2.zero; // Bottom-left corner
        rectTransform.anchorMax = Vector2.one;  // Top-right corner
        rectTransform.offsetMin = Vector2.zero; // Remove left/bottom offsets
        rectTransform.offsetMax = Vector2.zero; // Remove right/top offsets
    }
}
