using System.Collections.Generic;
using UnityEngine;

public class ProgressController2 : MonoBehaviour
{
    public List<GameObject> hintObjects;
        public int stepIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < hintObjects.Count; i++)
        {
            hintObjects[i].SetActive(false);
        }
        hintObjects[stepIndex].SetActive(true);
    }

    // Update is called once per frame
    

    public void NextStep()
    {
        stepIndex++;
        hintObjects[stepIndex].SetActive(true);
        Debug.Log("Advanced to next Step: " + stepIndex);
    }
}
