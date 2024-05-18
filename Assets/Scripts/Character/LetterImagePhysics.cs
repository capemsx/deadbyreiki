using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class LetterImagePhysics : MonoBehaviour
{
    public float moveDuration = 2f;  // Duration for which the image will move down
    public float moveDistance = 5f;  // Distance the image will move down
    private RawImage rawImage;
    private Vector3 originalPosition;

    void Start()
    {
        // Get the RawImage component
        rawImage = GetComponent<RawImage>();
    }

    IEnumerator MoveDown()
    {
        float elapsedTime = 0f;

        // Calculate the target position
        Vector3 targetPosition = new Vector3(originalPosition.x, originalPosition.y - moveDistance, originalPosition.z);

        // Show the image by enabling the RawImage component
        rawImage.enabled = true;

        // Move the image over time
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position is set exactly to the target position
        transform.position = targetPosition;

        // Hide the image by disabling the RawImage component
        rawImage.enabled = false;
    }

    internal void startFalling()
    {
        // Store the original position of the image
        originalPosition = transform.position;

        // Start the coroutine to move the image
        StartCoroutine(MoveDown());
    }
}