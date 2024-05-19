using UnityEngine;
using UnityEngine.UI;

public class BookPageController : MonoBehaviour
{
    public Book currentBook; // Reference to the current book
    public Button nextPageButton; // Button for turning page forward
    public Button prevPageButton; // Button for turning page backward

    void Start()
    {
        // Add listeners to the buttons
        nextPageButton.onClick.AddListener(TurnPageForward);
        prevPageButton.onClick.AddListener(TurnPageBackward);
    }

    public void setBook(Book pBook) {
        currentBook = pBook;
    }

    public Book getBook() {
        return currentBook;
    }

    void TurnPageForward()
    {
        if (currentBook != null)
        {
            currentBook.NextPage();
        }
    }

    void TurnPageBackward()
    {
        if (currentBook != null)
        {
            currentBook.PreviousPage();
        }
    }
}
