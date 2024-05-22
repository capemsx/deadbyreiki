using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string nextSceneName;
    public GameObject loadingText;

    public void LoadNextScene(string nextSceneName)
    {
        StartCoroutine(LoadSceneAsync(nextSceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Show loading text
        if (loadingText != null)
        {
            loadingText.SetActive(true);
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Hide loading text
        if (loadingText != null)
        {
            loadingText.SetActive(false);
        }
    }
}
