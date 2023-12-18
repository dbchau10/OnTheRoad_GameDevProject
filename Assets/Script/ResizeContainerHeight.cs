using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResizeContainerHeight : MonoBehaviour
{
    public RectTransform containerRectTransform;
    public TextMeshProUGUI alertContentText;
    private float minHeight = 182.4597f;

    private void Update()
    {
        UpdateContainerHeight();
    }

    public void UpdateContainerHeight()
    {
        if (alertContentText != null)
        {
            int characterCount = alertContentText.text.Length;

            float calculatedHeight = characterCount * 2f;

            float newHeight = Mathf.Max(calculatedHeight, minHeight);

            containerRectTransform.sizeDelta = new Vector2(containerRectTransform.sizeDelta.x, newHeight);
        }
    }
}
