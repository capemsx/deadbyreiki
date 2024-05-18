using UnityEngine;

public class RespawnItems : MonoBehaviour
{
    public Transform respawnPoint; // The point where items should respawn

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is tagged as "Item"
        if (other.CompareTag("Item"))
        {
            // Respawn the item at the respawn point
            RespawnItem(other.gameObject);
        }
    }

    private void RespawnItem(GameObject item)
    {
        // Get the Rigidbody component of the item
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Reset the velocity of the item
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Set the item's position to the respawn point
        item.transform.position = respawnPoint.position;

        // Activate the item if it was deactivated
        item.SetActive(true);
    }
}
