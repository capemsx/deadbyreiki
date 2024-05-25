using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FluteQuestController : MonoBehaviour
{
    public AudioClip finisher;
    public AudioClip failed;
    public GameObject closetDoor;
    public bool finishedQuest = false;

    private int currentStep = 0;
    private List<System.Action> methodSequence;
    private float inputTimer = 0f;
    private const float inputTimeout = 15f;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InitializeMethodSequence();
    }

    void Update()
    {
        inputTimer += Time.deltaTime;

        if (inputTimer > inputTimeout && currentStep > 0)
        {
            Debug.Log("No input for 5 seconds! Starting over.");
            currentStep = 0;
            inputTimer = 0f;
        }
    }

    void InitializeMethodSequence()
    {
        methodSequence = new List<System.Action>
        {
            Method4, // G

            Method7, // C"
            Method7, // C" 
            Method7, // C"
            Method7, // C"
            Method8, // D"

            Method9, // E"
            Method8, // D"
            Method7, // C"
            Method6, // H
            Method7, // C"
            Method4, // G

            Method5, // A
            Method5, // A
            Method5, // A
            Method5, // A
            Method6, // H
            Method7, // C"
            Method5, // A

            Method4, // G
            Method3, // F
            Method2, // E
            Method3, // F
            Method4, // G
            Method4, // G
        };
    }

    public void ExecuteMethod(int methodNumber)
    {
        if (currentStep < methodSequence.Count && methodSequence[currentStep].Method.Name == "Method" + methodNumber && !finishedQuest)
        {
            methodSequence[currentStep].Invoke();
            currentStep++;
            inputTimer = 0f; // Reset timer on correct input
            Debug.Log("Correct Note, advancing to next Step: " + currentStep);

            if (currentStep >= methodSequence.Count)
            {
                Debug.Log("Sequence Completed Successfully!");
                finishedQuest = true;
                currentStep = 0; // Reset or handle sequence completion as needed
                inputTimer = 0f; // Reset timer on completion
                audioSource.clip = finisher;
                audioSource.Play();
                closetDoor.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Wrong method! Starting over.");
            currentStep = 0;
            inputTimer = 0f; // Reset timer on failure
            audioSource.clip = failed;
            audioSource.Play();
        }
    }

    void Method1() { Debug.Log("Method1 executed."); }
    void Method2() { Debug.Log("Method2 executed."); }
    void Method3() { Debug.Log("Method3 executed."); }
    void Method4() { Debug.Log("Method4 executed."); }
    void Method5() { Debug.Log("Method5 executed."); }
    void Method6() { Debug.Log("Method6 executed."); }
    void Method7() { Debug.Log("Method7 executed."); }
    void Method8() { Debug.Log("Method8 executed."); }
    void Method9() { Debug.Log("Method9 executed."); }
    void Method10() { Debug.Log("Method10 executed."); }
    void Method11() { Debug.Log("Method11 executed."); }
    void Method12() { Debug.Log("Method12 executed."); }
    void Method13() { Debug.Log("Method13 executed."); }
}