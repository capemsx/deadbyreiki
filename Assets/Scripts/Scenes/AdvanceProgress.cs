using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceProgress : MonoBehaviour
{
    public Camera playerCam;
    public bool advancedToNextStep = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        float maxDistance = 4f;
        float maxAngle = 30f;

        Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.transform == transform)
            {
                // Berechnen des Winkels
                Vector3 toObject = (transform.position - playerCam.transform.position).normalized;
                float angle = Vector3.Angle(playerCam.transform.forward, toObject);

                // Überprüfen des Winkels
                if (angle < maxAngle)
                {
                    if (Input.GetKeyDown(KeyCode.E) && !advancedToNextStep)
                    {
                        ProgressController2 progressController = GameObject.Find("ProgressController").GetComponent<ProgressController2>();
                        progressController.NextStep();
                        advancedToNextStep = true;
                    }
                }
            }
        }
    }
}
