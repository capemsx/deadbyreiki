using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FluteScript : MonoBehaviour
{
    public ItemPickup itemPickup;
    public GameObject fluteObject;
    public RawImage fluteImage;
    public RawImage note1;
    public RawImage note2;
    public RawImage note3;
    public RawImage note4;
    public RawImage note5;
    public RawImage note6;
    public KeyCode note1Key;
    public KeyCode note2Key;
    public KeyCode note3Key;
    public KeyCode note4Key;
    public KeyCode note5Key;
    public KeyCode note6Key;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If the Flute is in the inventory, display the flute UI
        if (itemPickup.getInventory() == fluteObject)
        {
            fluteImage.enabled = true;
        }
        else
        {
            fluteImage.enabled = false;
            note1.enabled = false;
            note2.enabled = false;
            note3.enabled = false;
            note4.enabled = false;
            note5.enabled = false;
            note6.enabled = false;
        }
        
        if (Input.GetKeyDown(note1Key))
        {
            note1.enabled = true;
        }
        else if (Input.GetKeyUp(note1Key))
        {
            note1.enabled = false;
        }

        if (Input.GetKeyDown(note2Key))
        {
            note2.enabled = true;
        }
        else if (Input.GetKeyUp(note2Key))
        {
            note2.enabled = false;
        }

        if (Input.GetKeyDown(note3Key))
        {
            note3.enabled = true;
        }
        else if (Input.GetKeyUp(note3Key))
        {
            note3.enabled = false;
        }

        if (Input.GetKeyDown(note4Key))
        {
            note4.enabled = true;
        }
        else if (Input.GetKeyUp(note4Key))
        {
            note4.enabled = false;
        }

        if (Input.GetKeyDown(note5Key))
        {
            note5.enabled = true;
        }
        else if (Input.GetKeyUp(note5Key))
        {
            note5.enabled = false;
        }

        if (Input.GetKeyDown(note6Key))
        {
            note6.enabled = true;
        }
        else if (Input.GetKeyUp(note6Key))
        {
            note6.enabled = false;
        }
    }
}
