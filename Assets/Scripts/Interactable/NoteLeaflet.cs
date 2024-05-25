using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteLeaflet : MonoBehaviour
{
    public RawImage Background;

    public RawImage Segment1_1;
    public RawImage Segment1_2;
    public RawImage Segment1_3;
    public RawImage Segment1_4;
    public RawImage Segment1_5;
    public RawImage Segment2_1;
    public RawImage Segment2_2;
    public RawImage Segment2_3;
    public RawImage Segment2_4;
    public RawImage Segment2_5;

    public GameObject Segment1_1_Object;
    public GameObject Segment1_2_Object;
    public GameObject Segment1_3_Object;
    public GameObject Segment1_4_Object;
    public GameObject Segment1_5_Object;
    public GameObject Segment2_1_Object;
    public GameObject Segment2_2_Object;
    public GameObject Segment2_3_Object;
    public GameObject Segment2_4_Object;
    public GameObject Segment2_5_Object;

    public Button Segment1_Up;
    public Button Segment1_Down;
    public Button Segment2_Up;
    public Button Segment2_Down;

    private int Segment1Index = 1;
    private int Segment2Index = 1;

    // Start is called before the first frame update
    void Start()
    {
        Segment1_Up.onClick.AddListener(increaseSegment1);
        Segment1_Down.onClick.AddListener(decreaseSegment1);
        Segment2_Up.onClick.AddListener(increaseSegment2);
        Segment2_Down.onClick.AddListener(decreaseSegment2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Segment1Index > 5)
        {
            Segment1Index = 1;
        }
        else if (Segment1Index < 1)
        {
            Segment1Index = 5;
        }

        if (Segment2Index > 5)
        {
            Segment2Index = 1;
        }
        else if (Segment2Index < 1)
        {
            Segment2Index = 5;
        }

        updateUI();
    }

    void increaseSegment1()
    {
        Segment1Index++;
    }

    void decreaseSegment1()
    {
        Segment1Index--;
    }

    void increaseSegment2()
    {
        Segment2Index++;
    }

    void decreaseSegment2()
    {
        Segment2Index--;
    }

    void updateUI()
    {

        // Update Segment 1
        if (Segment1Index == 1)
        {
            Segment1_1.enabled = true;
            Segment1_2.enabled = false;
            Segment1_3.enabled = false;
            Segment1_4.enabled = false;
            Segment1_5.enabled = false;

            Segment1_1_Object.SetActive(true);
            Segment1_2_Object.SetActive(false);
            Segment1_3_Object.SetActive(false);
            Segment1_4_Object.SetActive(false);
            Segment1_5_Object.SetActive(false);
        }
        else if (Segment1Index == 2)
        {
            Segment1_1.enabled = false;
            Segment1_2.enabled = true;
            Segment1_3.enabled = false;
            Segment1_4.enabled = false;
            Segment1_5.enabled = false;

            Segment1_1_Object.SetActive(false);
            Segment1_2_Object.SetActive(true);
            Segment1_3_Object.SetActive(false);
            Segment1_4_Object.SetActive(false);
            Segment1_5_Object.SetActive(false);
        }
        else if (Segment1Index == 3)
        {
            Segment1_1.enabled = false;
            Segment1_2.enabled = false;
            Segment1_3.enabled = true;
            Segment1_4.enabled = false;
            Segment1_5.enabled = false;

            Segment1_1_Object.SetActive(false);
            Segment1_2_Object.SetActive(false);
            Segment1_3_Object.SetActive(true);
            Segment1_4_Object.SetActive(false);
            Segment1_5_Object.SetActive(false);
        }
        else if (Segment1Index == 4)
        {
            Segment1_1.enabled = false;
            Segment1_2.enabled = false;
            Segment1_3.enabled = false;
            Segment1_4.enabled = true;
            Segment1_5.enabled = false;

            Segment1_1_Object.SetActive(false);
            Segment1_2_Object.SetActive(false);
            Segment1_3_Object.SetActive(false);
            Segment1_4_Object.SetActive(true);
            Segment1_5_Object.SetActive(false);
        }
        else
        {
            Segment1_1.enabled = false;
            Segment1_2.enabled = false;
            Segment1_3.enabled = false;
            Segment1_4.enabled = false;
            Segment1_5.enabled = true;

            Segment1_1_Object.SetActive(false);
            Segment1_2_Object.SetActive(false);
            Segment1_3_Object.SetActive(false);
            Segment1_4_Object.SetActive(false);
            Segment1_5_Object.SetActive(true);
        }

        // Update Segment 2
        if (Segment2Index == 1)
        {
            Segment2_1.enabled = true;
            Segment2_2.enabled = false;
            Segment2_3.enabled = false;
            Segment2_4.enabled = false;
            Segment2_5.enabled = false;

            Segment2_1_Object.SetActive(true);
            Segment2_2_Object.SetActive(false);
            Segment2_3_Object.SetActive(false);
            Segment2_4_Object.SetActive(false);
            Segment2_5_Object.SetActive(false);
        }
        else if (Segment2Index == 2)
        {
            Segment2_1.enabled = false;
            Segment2_2.enabled = true;
            Segment2_3.enabled = false;
            Segment2_4.enabled = false;
            Segment2_5.enabled = false;

            Segment2_1_Object.SetActive(false);
            Segment2_2_Object.SetActive(true);
            Segment2_3_Object.SetActive(false);
            Segment2_4_Object.SetActive(false);
            Segment2_5_Object.SetActive(false);
        }
        else if (Segment2Index == 3)
        {
            Segment2_1.enabled = false;
            Segment2_2.enabled = false;
            Segment2_3.enabled = true;
            Segment2_4.enabled = false;
            Segment2_5.enabled = false;

            Segment2_1_Object.SetActive(false);
            Segment2_2_Object.SetActive(false);
            Segment2_3_Object.SetActive(true);
            Segment2_4_Object.SetActive(false);
            Segment2_5_Object.SetActive(false);
        }
        else if (Segment2Index == 4)
        {
            Segment2_1.enabled = false;
            Segment2_2.enabled = false;
            Segment2_3.enabled = false;
            Segment2_4.enabled = true;
            Segment2_5.enabled = false;

            Segment2_1_Object.SetActive(false);
            Segment2_2_Object.SetActive(false);
            Segment2_3_Object.SetActive(false);
            Segment2_4_Object.SetActive(true);
            Segment2_5_Object.SetActive(false);
        }
        else
        {
            Segment2_1.enabled = false;
            Segment2_2.enabled = false;
            Segment2_3.enabled = false;
            Segment2_4.enabled = false;
            Segment2_5.enabled = true;

            Segment2_1_Object.SetActive(false);
            Segment2_2_Object.SetActive(false);
            Segment2_3_Object.SetActive(false);
            Segment2_4_Object.SetActive(false);
            Segment2_5_Object.SetActive(true);
        }
    }
}
