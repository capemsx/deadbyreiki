using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
 
public class SelectionManager : MonoBehaviour
{
 
    public GameObject InteractionInfo;
    public Camera playerCam;
    public int InteractDistance = 4;
    TextMeshProUGUI interaction_text;
    
 
    private void Start()
    {
        
        interaction_text = InteractionInfo.GetComponent<TextMeshProUGUI>();
    }
 
    void Update()
    {
        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, InteractDistance))
        {
            var selectionTransform = hit.transform;
            InteractableObject1 interactable = selectionTransform.GetComponent<InteractableObject1>();

            if (interactable)
            {
                InteractionInfo.SetActive(true);
                interaction_text.text = interactable.GetItemName();
            }
            else
            {
                InteractionInfo.SetActive(false);
            }

        }
        else
        {
            InteractionInfo.SetActive(false);
        }
    }
}