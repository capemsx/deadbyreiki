using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskLampController : MonoBehaviour
{
    public ItemPickup itemPickup;
    public GameObject deskLamp;
    public GameObject playerLight;

    // Update is called once per frame
    void Update()
    {
        if (itemPickup.getInventory() == deskLamp)
        {
            playerLight.SetActive(true);
        }
        else
        {
            playerLight.SetActive(false);
        }
    }
}
