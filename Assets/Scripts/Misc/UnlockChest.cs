using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChest : MonoBehaviour
{
    public GameObject itemToHide;

    public void unlock() {
        itemToHide.SetActive(false);
    }
}
