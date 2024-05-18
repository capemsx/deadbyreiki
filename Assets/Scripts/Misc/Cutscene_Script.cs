using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_Script : MonoBehaviour
{
    float initialStartTime;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Debugging active!");
        initialStartTime = Time.time * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time * 1000 - initialStartTime > 9000) {
            Debug.Log("Cutscene Script ended!");
            Destroy(this);
        }
        
        
    }
}
