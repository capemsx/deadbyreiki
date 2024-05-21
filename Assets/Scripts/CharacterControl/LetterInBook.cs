using GLTFast.Schema;
using UnityEngine;
using UnityEngine.UI;

public class LetterInBook : MonoBehaviour
{
    public float distanceInFrontOfCamera = 0.2f; // Distance from the camera where the object will be placed
    public Quaternion letterRotation = Quaternion.identity; // Rotation of the teleported letter
    public GameObject bookObject; // The actual book GameObject
    public Book bookInteractable; // The script component of the book
    public LetterImagePhysics letterImagePhysics;
    public int minPage;
    public int maxPage;
    public int letterPage;
    public bool foundLetter = false;
    public UnityEngine.Camera playerCam;

    void Start()
    {
        // Randomly assign the letter page within the specified range
        letterPage = Random.Range(minPage, maxPage);
        Debug.Log("Letter is on page: " + letterPage);
    }

    void Update()
    {
        if (bookInteractable == null || bookObject == null)
        {
            Debug.LogError("Book interactable or book object is not assigned!");
            return;
        }

        // Check the current page of the book
        int currentPage = bookInteractable.getPage();
        Debug.Log("Current page: " + currentPage);

        // Check if the current page matches the letter page and if the letter hasn't been teleported yet
        if (currentPage == letterPage && !foundLetter)
        {
            letterImagePhysics.startFalling();
            Teleport();
            foundLetter = true;
            Debug.Log("Letter teleported to the camera view.");
        }
    }

    void Teleport()
    {
        if (playerCam == null)
        {
            Debug.LogError("Main camera not found!");
            return;
        }

        // Calculate the new position in front of the camera
        Vector3 newPosition = playerCam.transform.position + playerCam.transform.forward * distanceInFrontOfCamera;

        // Set the object's position and rotation
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        Debug.Log("Letter position set to: " + newPosition);
        Debug.Log("Letter rotation set to: " + letterRotation);
    }
}
