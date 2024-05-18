using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject interactableObject;
    public Camera playerCam;
    public GameObject uiCameraInteractionHint;

    private bool isInteractable = false;

    void Start()
    {

    }

    void Update()
    {
        // Überprüfe, ob der Spieler ESC drückt, um das UI zu schließen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiObject.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        float maxDistance = 500f;
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
                        uiObject.SetActive(true);
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

        
    }

    void triggerInteractionHint(bool show)
    {
        if (show)
        {
            if (!isInteractable) uiCameraInteractionHint.SetActive(true);
        }
        else
        {
            if (isInteractable) uiCameraInteractionHint.SetActive(false);
        }
        isInteractable = show;
    }
}
