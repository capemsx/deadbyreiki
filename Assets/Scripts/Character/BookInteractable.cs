using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Book : MonoBehaviour
{
    public string imagesFolder = "PDFImages"; // Folder in Resources
    public bool isOpen = false; // Flag to track if the book is open
    public RawImage leftPageDisplay;
    public RawImage rightPageDisplay;
    public Image bookBackground;
    public Button buttonForwards;
    public Button buttonBackwards;
    public PlayerMovement playerMovement;
    public PlayerCam mouseMovement;
    public int pageNumber = 0;
    private Texture2D[] pages;

    public void Interact()
    {
        if (isOpen)
        {
            CloseBook();
        }
        else
        {
            OpenBook();
        }
    }

    public void OpenBook()
    {
        // Logic to open the PDF file
        LoadImages();
        DisplayPages(pageNumber);
        isOpen = true;
        // Disable player movement
        playerMovement.allowPlayerMovement(false);
        mouseMovement.allowPlayerMovement(false);

        // Unlock cursor and make it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        leftPageDisplay.enabled = true; // Show the left page image
        rightPageDisplay.enabled = true; // Show the right page image
        buttonForwards.gameObject.SetActive(true); // Show the forward button
        buttonBackwards.gameObject.SetActive(true); // Show the backward button
        bookBackground.gameObject.SetActive(true); // Show the backward button
    }

    public void CloseBook()
    {

        // Enable player movement
        playerMovement.allowPlayerMovement(true);
        mouseMovement.allowPlayerMovement(true);

        // Lock cursor and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isOpen = false;
        leftPageDisplay.enabled = false; // Hide the left page image
        rightPageDisplay.enabled = false; // Hide the right page image
        buttonForwards.gameObject.SetActive(false); // Hide the forward button
        buttonBackwards.gameObject.SetActive(false); // Hide the backward button
        bookBackground.gameObject.SetActive(false); // Show the backward button
    }

    void LoadImages()
    {
        Object[] textures = Resources.LoadAll(imagesFolder, typeof(Texture2D));
        pages = new Texture2D[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
            pages[i] = (Texture2D)textures[i];
        }
    }

    void DisplayPages(int pageNum)
    {
        if (pages == null || pageNum < 0 || pageNum >= pages.Length)
        {
            Debug.LogError("Invalid page number or images not loaded.");
            return;
        }

        // Calculate the left and right page indices
        int leftPageIndex = Mathf.Clamp(pageNum * 2, 0, pages.Length - 1);
        int rightPageIndex = Mathf.Clamp(leftPageIndex + 1, 0, pages.Length - 1);

        // Display the left and right pages
        leftPageDisplay.texture = pages[leftPageIndex];
        rightPageDisplay.texture = rightPageIndex < pages.Length ? pages[rightPageIndex] : null;
    }

    public void NextPage()
    {
        pageNumber++;
        if (pageNumber >= (pages.Length + 1) / 2)
            pageNumber = (pages.Length + 1) / 2 - 1;

        DisplayPages(pageNumber);
    }

    public void PreviousPage()
    {
        pageNumber--;
        if (pageNumber < 0)
            pageNumber = 0;

        DisplayPages(pageNumber);
    }

    public int getPage() {
        return pageNumber;
    }
}
