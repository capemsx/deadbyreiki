using UnityEngine;

public class LibraryCameraOpener : MonoBehaviour
{
    float initTS;
    public Camera cineCamera;
    public Camera playerCamera;
    public GameObject crosshair;
    public PlayerMovement playerMovement;
    public PlayerCam playerCam;
    public bool doOpener;
    void Start()
    {
        initTS = Time.time;
        playerMovement.allowPlayerMovement(false);
        playerCam.allowPlayerMovement(false);
        crosshair.SetActive(false);
    }

    void Update()
    {
        //wait 3 seconds
        if ((Time.time - initTS > 3) && doOpener)
        {
            cineCamera.enabled = false;
            playerCamera.enabled = true;
            playerMovement.allowPlayerMovement(true);
            playerCam.allowPlayerMovement(true);
            crosshair.SetActive(true);
        } else if (!doOpener) {
            cineCamera.enabled = false;
            playerCamera.enabled = true;
            playerMovement.allowPlayerMovement(true);
            playerCam.allowPlayerMovement(true);
            crosshair.SetActive(true);
        }
    }
}
