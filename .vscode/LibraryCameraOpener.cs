using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryCameraOpener : MonoBehaviour
{
    float initTS;
    public Camera cineCamera;
    public Camera playerCamera;
    void Start()
    {
        initTS = Time.time;
    }

    void Update()
    {
        //wait 3 seconds
        if (Time.time - initTS > 3)
        {
            cineCamera.enabled = false;
            playerCamera.enabled = true;
        }
    }
}
