using UnityEngine;
using TMPro;
using System;

public class MoveAndActivate : MonoBehaviour
{

    public GameObject interactableObject;
    public Camera playerCam;
    public GameObject uiCameraInteractionHint;
    public GameObject itemSelector;
    public float moveDuration = 2.0f; // Duration to move the object
    public float moveSpeed = 1.0f;    // Speed of the movement
    public GameObject objectToActivate; // The object to activate after movement
    public GameObject objectToMove;
    public String displayName;

    private float moveTimer = 0.0f;   // Timer to track the movement duration
    private bool isMoving = true;     // Flag to check if the object is still moving
    private bool shouldMove;
    private bool isInteractable = false;

    void Update()
    {
        float maxDistance = 4f;
        float maxAngle = 30f;

        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Durchführen des Raycasts
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.transform == interactableObject.transform)
            {
                // Berechnen des Winkels
                Vector3 toObject = (interactableObject.transform.position - playerCam.transform.position).normalized;
                float angle = Vector3.Angle(playerCam.transform.forward, toObject);

                // Überprüfen des Winkels
                if (angle < maxAngle)
                {
                    triggerInteractionHint(true);

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        shouldMove = true;
                    }
                }
                else
                {
                    triggerInteractionHint(false);

                }
            }
            else
            {
                triggerInteractionHint(false);
            }
        }
        else
        {
            triggerInteractionHint(false);
        }

        if (shouldMove)
        {
            startMoving();
        }
    }

    void startMoving()
    {
        if (isMoving)
        {
            // Move the object to the left
            objectToMove.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Update the timer
            moveTimer += Time.deltaTime;

            // Check if the movement duration is reached
            if (moveTimer >= moveDuration)
            {
                isMoving = false; // Stop moving
                ActivateObject(); // Activate the other object
            }
        }
    }

    void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }

    void triggerInteractionHint(bool show)
    {
        if (show)
        {
            if (!isInteractable)
            {

                uiCameraInteractionHint.SetActive(true);

                itemSelector.SetActive(true);
                itemSelector.GetComponent<TextMeshProUGUI>().SetText(displayName);
            }
        }
        else
        {
            if (isInteractable)
            {
                uiCameraInteractionHint.SetActive(false);
                itemSelector.SetActive(false);
            }
        }
        isInteractable = show;
    }
}
