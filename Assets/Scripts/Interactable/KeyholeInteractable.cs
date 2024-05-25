using UnityEngine;
using System.Collections.Generic;

public class KeyholeInteraction : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float interactionRange = 4f; // Maximum distance for interaction
    public KeyCode interactionKey = KeyCode.E; // Interaction key
    public ItemPickup playerInventory; // Reference to the player's inventory script
    public GameObject keyRequired;
    public GameObject uiCameraInteractionHint;
    public UnlockChest unlockObject;

    void Update()
    {

        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            if (hit.transform == transform)
            {
                if (playerInventory.getInventory() == keyRequired)
                {
                    uiCameraInteractionHint.SetActive(true);
                }
                else
                {
                    uiCameraInteractionHint.SetActive(false);
                }
                if (Input.GetKeyDown(interactionKey) && playerInventory.getInventory() == keyRequired)
                {
                    unlockObject.unlock();
                }
            }

        }
    }
}