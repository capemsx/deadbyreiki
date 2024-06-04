using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitCamera : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string sceneToLoad;
    public Camera cineCamera;
    public Camera playerCamera;
    public GameObject uiCameraInteractionHint;
    public GameObject itemSelector;
    public GameObject crosshair;
    public GameObject credits;
    private void Start()
    {
        playerCamera.enabled = false;
        cineCamera.enabled = true;
        itemSelector.SetActive(false);
        uiCameraInteractionHint.SetActive(false);
        crosshair.SetActive(false);
        StartCoroutine(SwitchCamera());
    }

    private void Update()
    {
        itemSelector.SetActive(false);
        uiCameraInteractionHint.SetActive(false);
        crosshair.SetActive(false);
    }

    private IEnumerator SwitchCamera()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(9.5f);
        credits.SetActive(true);
        yield return new WaitForSeconds(140);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        sceneLoader.LoadNextScene(sceneToLoad);
        Destroy(this);
    }
}
