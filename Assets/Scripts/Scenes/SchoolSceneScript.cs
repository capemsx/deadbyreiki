using UnityEngine;

public class SchoolSceneScript : MonoBehaviour
{
    Camera camera;
    public GameObject reiki;
    public SceneLoader sceneLoader;
    public float showDelay = 3.5f; // Zeitverzögerung in Sekunden
    public float switchDelay = 6.5f; // Zeitverzögerung in Sekunden

    // Start is called before the first frame update
    void Start()
    {
        reiki.SetActive(false); // Verstecke reiki zu Beginn
        Invoke("ShowReiki", showDelay); // Zeige reiki nach der Zeitverzögerung
        Invoke("SwitchScene", switchDelay); // Zeige reiki nach der Zeitverzögerung
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowReiki()
    {
        reiki.SetActive(true); // Zeige reiki
    }

    void SwitchScene()
    {
        sceneLoader.LoadNextScene("TruckCutScene"); // Lade nächste Szene
    }
}