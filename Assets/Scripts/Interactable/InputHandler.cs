using UnityEngine;
using TMPro;

public class InputHandler : MonoBehaviour
{
    public TMP_InputField tmpInputField;
    public TMP_Text outputText;

    public bool advancedToNextStep = false;
    private bool isInputFieldFocused;

    void Start()
    {
        if (tmpInputField == null)
        {
            Debug.LogError("TMP_InputField not assigned.");
        }

        if (outputText == null)
        {
            Debug.LogError("Output TMP_Text not assigned.");
        }

        tmpInputField.onValueChanged.AddListener(OnInputValueChanged);
        tmpInputField.onEndEdit.AddListener(OnInputEndEdit);
        tmpInputField.onSelect.AddListener(OnInputFieldSelect);
        tmpInputField.onDeselect.AddListener(OnInputFieldDeselect);
    }

    void Update()
    {

    }

    void OnInputFieldSelect(string text)
    {
        isInputFieldFocused = true;
    }

    void OnInputFieldDeselect(string text)
    {
        isInputFieldFocused = false;
    }

    public void OnInputValueChanged(string text)
    {
        outputText.text = "Current Input: " + text;

        if (string.Equals(text, "Friedrich", System.StringComparison.OrdinalIgnoreCase) && !advancedToNextStep)
        {
            CorrectInput();
        }
    }

    public void OnInputEndEdit(string text)
    {
        Debug.Log("Final Input: " + text);
    }

    public bool GetIsInputFieldFocused()
    {
        return isInputFieldFocused;
    }

    void CorrectInput()
    {
        ProgressController2 progressController = GameObject.Find("ProgressController").GetComponent<ProgressController2>();
        progressController.NextStep();
        advancedToNextStep = true;
    }
}
