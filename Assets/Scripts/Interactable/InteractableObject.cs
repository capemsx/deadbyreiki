using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject interactableObject;
    public Camera playerCam;
    public GameObject uiCameraInteractionHint;
    public GameObject itemSelector;
    public BookPageController bookPageController;
    public PlayerMovement playerMovement;
    public PlayerCam mouseMovement;
    public ItemPickup itemPickup;
    public String displayName;
    public bool isInteractableObject;

    private bool isBookOpen = false;
    private bool isUIOpen = false;
    private bool isInteractable = false;

    void Update()
    {

        float maxDistance = 4f;
        float maxAngle = 30f;

        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Überprüfe, ob der Spieler E drückt, um das UI zu schließen
        if (Input.GetKeyDown(KeyCode.E) && isInteractableObject && (isUIOpen || isBookOpen))
        {
            if (uiObject && isUIOpen)
            {
                isUIOpen = false;
                uiObject.SetActive(false);
                itemPickup.setIsUIOpen(false);
                Cursor.lockState = CursorLockMode.Locked;
                playerMovement.allowPlayerMovement(true);
                mouseMovement.allowPlayerMovement(true);
            }
            else if (isBookOpen)
            {
                isBookOpen = false;
                itemPickup.setIsUIOpen(false);
                interactableObject.GetComponent<Book>().CloseBook();
                bookPageController.setBook(null);
                Cursor.lockState = CursorLockMode.Locked;
                playerMovement.allowPlayerMovement(true);
                mouseMovement.allowPlayerMovement(true);
            }
        }
        else // Durchführen des Raycasts
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

                    if (Input.GetKeyDown(KeyCode.E) && isInteractableObject)
                    {
                        if (uiObject && !isUIOpen)
                        {
                            isUIOpen = true;
                            uiObject.SetActive(true);
                            itemPickup.setIsUIOpen(true);
                            playerMovement.allowPlayerMovement(false);
                            mouseMovement.allowPlayerMovement(false);
                        }
                        else if (!isBookOpen)
                        {
                            isBookOpen = true;
                            itemPickup.setIsUIOpen(true);
                            bookPageController.setBook(interactableObject.GetComponent<Book>());
                            interactableObject.GetComponent<Book>().OpenBook();
                            playerMovement.allowPlayerMovement(false);
                            mouseMovement.allowPlayerMovement(false);
                        }
                        Cursor.lockState = CursorLockMode.None;
                        return;
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

        if (!(itemPickup.getInventory() == null))
        {
            uiCameraInteractionHint.SetActive(false);
        }

    }

    void triggerInteractionHint(bool show)
    {
        if (show)
        {
            if (!isInteractable)
            {
                if (isInteractableObject && itemPickup.getInventory() == null)
                {
                    uiCameraInteractionHint.SetActive(true);
                }
                else
                {
                    uiCameraInteractionHint.SetActive(false);
                }
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
