using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    // Reference to the button in the UI
    public Button startButton;
    public SceneLoader sceneLoader;
    public string sceneToLoad;

    void Start()
    {
        Debug.Log("Wee, Woo");
        startButton.onClick.AddListener(OnButtonPress);
    }

    // Method to be called when the button is pressed
    public void OnButtonPress()
    {
        Debug.Log("Button was pressed!");
        sceneLoader.LoadNextScene(sceneToLoad);
    }

}
