using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI itemNameText; // Reference to the TextMeshPro Text element to display the item name
    private ItemPickup itemPickupScript; // Reference to the ItemPickup script to access the inventory

    void Start()
    {
        // Find the ItemPickup script attached to the player GameObject
        itemPickupScript = FindObjectOfType<ItemPickup>();

        // Check if the ItemPickup script was found
        if (itemPickupScript == null)
        {
            Debug.LogError("ItemPickup script not found. Make sure it's attached to the player GameObject.");
            return;
        }

        // Set the initial text to display the name of the item in the inventory (if any)
        UpdateItemName();
    }

    void Update()
    {
        // Update the displayed item name in case the inventory changes
        UpdateItemName();
    }

    void UpdateItemName()
    {
        // Check if there is an item in the inventory
        if (itemPickupScript.inventory.Count > 0)
        {
            // Get the name of the item in the inventory using InteractableObject script
            InteractableObject1 interactableObject = itemPickupScript.inventory[0].GetComponent<InteractableObject1>();
            if (interactableObject != null)
            {
                string itemName = interactableObject.GetItemName();
                // Update the TextMeshPro Text element to display the item name
                itemNameText.text = "Current Item: " + itemName;
            }
        }
        else
        {
            // If there's no item in the inventory, display a default message
            itemNameText.text = " ";
        }
    }
}
