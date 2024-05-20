using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombinationLock : MonoBehaviour
{
    public GameObject up1Button;
    public GameObject down1Button;
    public GameObject up2Button;
    public GameObject down2Button;
    public GameObject up3Button;
    public GameObject down3Button;
    public GameObject up4Button;
    public GameObject down4Button;
    public GameObject resultText;
    public UnlockChest unlockObject;

    private int[] combination = new int[4];
    private int[] correctCombination = { 1, 2, 3, 4 };

    void Start()
    {
        up1Button.GetComponent<Button>().onClick.AddListener(() => editDigit(0, true));
        down1Button.GetComponent<Button>().onClick.AddListener(() => editDigit(0, false));
        up2Button.GetComponent<Button>().onClick.AddListener(() => editDigit(1, true));
        down2Button.GetComponent<Button>().onClick.AddListener(() => editDigit(1, false));
        up3Button.GetComponent<Button>().onClick.AddListener(() => editDigit(2, true));
        down3Button.GetComponent<Button>().onClick.AddListener(() => editDigit(2, false));
        up4Button.GetComponent<Button>().onClick.AddListener(() => editDigit(3, true));
        down4Button.GetComponent<Button>().onClick.AddListener(() => editDigit(3, false));
    }

    public void editDigit(int digitId, bool increase)
    {
        Debug.Log("Edit digit " + digitId + " with increase: " + increase);
        if (increase)
        {
            combination[digitId] = (combination[digitId] + 1) % 10;
        }
        else
        {
            combination[digitId] = (10 + combination[digitId] - 1) % 10;
        }

        updateResultText();
    }

    private void updateResultText()
    {
        string currentCombination = string.Join("", combination);
        resultText.GetComponent<TextMeshProUGUI>().text = currentCombination;
        if (currentCombination == "1741")
        {
            Debug.Log("Correct combination entered!");
            unlockObject.unlock();
            ProgressController progressController = GameObject.Find("ProgressController").GetComponent<ProgressController>();
            progressController.runNextStep(1);
            progressController.hideAllDialogs();
        }

    }
}