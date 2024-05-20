using UnityEngine;
using System.Collections.Generic;

public class ItemPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.F; // Key to press to pick up and drop items
    public GameObject inventory; // List to store picked-up items
    private GameObject player;
    public Camera playerCam;
    public BookPageController bookPageController;
    //public GameObject uiCameraInteractionHint;

    public GameObject getInventory() {
        return inventory;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Check if player GameObject and main camera were found
        if (player == null)
        {
            Debug.LogError("Player GameObject not found. Make sure the player is tagged as 'Player'.");
        }
        if (playerCam == null)
        {
            Debug.LogError("Main camera not found in the scene.");
        }
    }

    void Update()
    {
        if (player != null && playerCam != null)
        {
            if (Input.GetKeyDown(pickupKey))
            {
                if (inventory == null)
                {
                    CheckForItems();
                }
                else
                {
                    DropItemFromInventory();
                }
            }
        }

    }

    void CheckForItems()
    {
        // Cast a ray from the center of the screen
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 4f) && bookPageController.getBook() == null)
        {
            // Check if the raycast hit an object tagged as "Item"
            if (hit.collider.CompareTag("Item"))
            {
                PickUpItem(hit.collider.gameObject);
            }
        }
    }

    void PickUpItem(GameObject item)
    {
        // Add the item to the inventory
        inventory = item;

        // Deactivate the item GameObject
        item.SetActive(false);
    }

    void DropItemFromInventory()
    {
        if (inventory != null)
        {
            // Get the item to drop from the inventory list
            GameObject itemToDrop = inventory;

            // Activate the item GameObject
            itemToDrop.SetActive(true);

            // Position the item where the player is looking
            itemToDrop.transform.position = GetDropPosition();

            // Set the item's rotation to match the camera's Z rotation only
            Vector3 cameraRotation = playerCam.transform.eulerAngles;
            itemToDrop.transform.rotation = Quaternion.Euler(cameraRotation.x, cameraRotation.y, cameraRotation.z);

            // Reset the item's velocity
            Rigidbody rb = itemToDrop.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // Apply a forward force to simulate dropping
                rb.AddForce(playerCam.transform.forward * 2f, ForceMode.Impulse);
            }

            // Remove the item from the inventory
            inventory = null;
        }
    }

    Vector3 GetDropPosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, Mathf.Infinity))
        {
            // Calculate the drop position
            Vector3 dropPosition = hit.point;

            // Ensure the drop position is above the ground
            dropPosition += Vector3.up * 0.2f;

            // Limit the maximum drop distance from the player
            float maxDropDistance = 4f;
            float distanceToHit = Vector3.Distance(playerCam.transform.position, hit.point);
            if (distanceToHit > maxDropDistance)
            {
                dropPosition = playerCam.transform.position + playerCam.transform.forward * maxDropDistance;
            }

            return dropPosition;
        }
        else
        {
            // If raycast doesn't hit anything, return a default drop position
            return playerCam.transform.position + playerCam.transform.forward * 2f;
        }
    }
}
