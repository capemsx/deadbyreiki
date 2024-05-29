using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;

public class ExitCamera : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public string sceneToLoad;
    private void Start()
    {
        StartCoroutine(SwitchCamera());
    }

    private IEnumerator SwitchCamera()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(10f);
        sceneLoader.LoadNextScene(sceneToLoad);
        Destroy(this);
    }
}
