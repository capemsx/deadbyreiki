using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
    public KeyCode escapeKey;
    public GameObject escapeMenuUI; // Reference to the escape menu UI panel
    public Button quitGameButton;
    public Button restartGameButton;
    public Button unpauseGameButton;
    public Slider sensitivitySlider; // Reference to the sensitivity slider
    public Text sensitivityValueText; // Reference to the sensitivity value text
    public PlayerCam playerCam;

    private bool isPaused = false;
    private bool cursorState;
    public static float mouseSensitivity = 100.0f; // Default mouse sensitivity

    void Start()
    {
        quitGameButton.onClick.AddListener(QuitGame);
        restartGameButton.onClick.AddListener(RestartGame);
        unpauseGameButton.onClick.AddListener(ResumeGame);

        sensitivitySlider.value = mouseSensitivity;
        sensitivitySlider.onValueChanged.AddListener(delegate { OnSensitivityChange(); });
        UpdateSensitivityValueText();
    }

    void Update()
    {
        if (Input.GetKeyDown(escapeKey))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        escapeMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
        if (cursorState)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }

    void PauseGame()
    {
        escapeMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        isPaused = true;
        
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            cursorState = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            cursorState = false;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void RestartGame()
    {
        Debug.Log("Restarting game...");
        Time.timeScale = 1f; // Ensure time scale is reset
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
        escapeMenuUI.SetActive(false);
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnSensitivityChange()
    {
        mouseSensitivity = sensitivitySlider.value;
        UpdateSensitivityValueText();
        playerCam.setMouseSensitivity(mouseSensitivity * 2);
        Debug.Log("Mouse Sensitivity changed to: " + mouseSensitivity * 2);
    }

    private void UpdateSensitivityValueText()
    {
        if (sensitivityValueText != null)
        {
            sensitivityValueText.text = mouseSensitivity.ToString("F2");
        }
    }
}
