using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.F; // Key to press to pick up and drop items
    public GameObject inventory; // The item currently picked up
    private GameObject player;
    public Camera playerCam;
    public BookPageController bookPageController;

    private bool isUIOpen = false;

    public GameObject getInventory() {
        return inventory;
    }

    public void setIsUIOpen(bool pIsUIOpen) {
        isUIOpen = pIsUIOpen;
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

        if (Physics.Raycast(ray, out hit, 4f))
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
        if (!isUIOpen)
        {
            // Add the item to the inventory
            inventory = item;

            // Deactivate the item GameObject
            item.SetActive(false);
        }
    }

    void DropItemFromInventory()
    {
        if (inventory != null)
        {
            // Get the item to drop from the inventory list
            GameObject itemToDrop = inventory;

            // Activate the item GameObject
            itemToDrop.SetActive(true);

            // Calculate the intended drop position based on the camera's forward direction
            Vector3 intendedDropPosition = playerCam.transform.position + playerCam.transform.forward * 1.5f;

            // Perform a raycast to check for obstacles
            RaycastHit hit;
            Vector3 dropPosition;
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, 1.5f))
            {
                // If an obstacle is hit, adjust the drop position to be slightly in front of the hit point
                dropPosition = hit.point - playerCam.transform.forward * 0.5f;
            }
            else
            {
                // If no obstacle is hit, drop the item in front of the player's face
                dropPosition = intendedDropPosition;
            }

            // Set the item's position and rotation
            itemToDrop.transform.position = dropPosition;
            itemToDrop.transform.rotation = playerCam.transform.rotation;

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
}
