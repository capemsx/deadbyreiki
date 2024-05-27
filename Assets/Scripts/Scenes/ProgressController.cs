using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    public List<GameObject> hintObjects;
    public List<GameObject> hintUIs;

    List<int> autoContinueIndizes = new List<int>() { 0 , 2};

    public int stepIndex = 0;

    void Start()
    {
        // Stellen Sie sicher, dass nur das erste Objekt sichtbar ist
        for (int i = 1; i < hintObjects.Count; i++)
        {
            hintObjects[i].SetActive(false);
        }
        for (int i = 0; i < hintUIs.Count; i++)
        {
            hintUIs[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hintUIs.Count; i++)
        {
            if (hintUIs[i].activeSelf && stepIndex == i)
            {

                if (autoContinueIndizes.Contains(i)) runNextStep(i);

            }

        }
    }

    public void runNextStep(int i)
    {
        stepIndex = i + 1;
        if (stepIndex > 2)
        {
            hintObjects[stepIndex - 1].SetActive(false);
        }
        hintObjects[stepIndex].SetActive(true);
    }

    public void hideAllDialogs()
    {
        foreach (GameObject hintUI in hintUIs)
        {
            hintUI.SetActive(false);
        }
    }
}