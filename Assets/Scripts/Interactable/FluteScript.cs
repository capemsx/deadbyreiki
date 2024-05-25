using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FluteScript : MonoBehaviour
{
    public ItemPickup itemPickup;
    public GameObject fluteObject;
    public RawImage fluteImage;
    public RawImage note1;
    public RawImage note2;
    public RawImage note3;
    public RawImage note4;
    public RawImage note5;
    public RawImage note6;
    public RawImage note7;
    public KeyCode note1Key;
    public KeyCode note2Key;
    public KeyCode note3Key;
    public KeyCode note4Key;
    public KeyCode note5Key;
    public KeyCode note6Key;
    public KeyCode note7Key;
    public KeyCode playNote;
    public AudioClip note01Audio;
    public AudioClip note02Audio;
    public AudioClip note03Audio;
    public AudioClip note04Audio;
    public AudioClip note05Audio;
    public AudioClip note06Audio;
    public AudioClip note07Audio;
    public AudioClip note08Audio;
    public AudioClip note09Audio;
    public AudioClip note10Audio;
    public AudioClip note11Audio;
    public AudioClip note12Audio;
    public AudioClip note13Audio;

    private AudioSource audioSource;
    private Dictionary<string, AudioClip> noteMapping;
    private float cooldownTimer = 0f;
    private const float inputCooldown = 1f; // Cooldown period in seconds

    // Start is called before the first frame update
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        // Initialize the mapping of button combinations to notes
        noteMapping = new Dictionary<string, AudioClip>
        {
            { "1111111", note01Audio }, // D
            { "1111110", note02Audio }, // E
            { "1111100", note03Audio }, // F
            { "1111000", note04Audio }, // G
            { "1110000", note05Audio }, // A
            { "1100000", note06Audio }, // H
            { "1010000", note07Audio }, // C"
            { "0010000", note08Audio }, // D"
            { "0111110", note09Audio }, // E"
            { "0111100", note10Audio }, // F"
            { "0111000", note11Audio }, // G"
            { "0110000", note12Audio }, // A"
            { "0110110", note13Audio }, // C"
        };
    }

    // Update is called once per frame
    void Update()
    {
        displayUI();
        cooldownTimer += Time.deltaTime;

        if (audioSource == null) return; // Exit if AudioSource is not present

        // Check if the spacebar is pressed
        if (Input.GetKey(playNote) && (cooldownTimer >= inputCooldown))
        {
            // Check which keys are pressed and form a key string
            string key = (Input.GetKey(note1Key) ? "1" : "0") +
                         (Input.GetKey(note2Key) ? "1" : "0") +
                         (Input.GetKey(note3Key) ? "1" : "0") +
                         (Input.GetKey(note4Key) ? "1" : "0") +
                         (Input.GetKey(note5Key) ? "1" : "0") +
                         (Input.GetKey(note6Key) ? "1" : "0") +
                         (Input.GetKey(note7Key) ? "1" : "0");

            // Play the corresponding note if the combination exists in the dictionary
            if (noteMapping.ContainsKey(key))
            {
                PlaySound(noteMapping[key]);
                cooldownTimer = 0f;
            }
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource.clip != clip || !audioSource.isPlaying)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

        if (clip == note01Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(1);
        else if (clip == note02Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(2);
        else if (clip == note03Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(3);
        else if (clip == note04Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(4);
        else if (clip == note05Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(5);
        else if (clip == note06Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(6);
        else if (clip == note07Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(7);
        else if (clip == note08Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(8);
        else if (clip == note09Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(9);
        else if (clip == note10Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(10);
        else if (clip == note11Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(11);
        else if (clip == note12Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(12);
        else if (clip == note13Audio)
            GetComponent<FluteQuestController>().ExecuteMethod(13);
    }

    private void displayUI()
    {
        // If the Flute is in the inventory, display the flute UI
        if (itemPickup.getInventory() == fluteObject)
        {
            fluteImage.enabled = true;
        }
        else
        {
            fluteImage.enabled = false;
            note1.enabled = false;
            note2.enabled = false;
            note3.enabled = false;
            note4.enabled = false;
            note5.enabled = false;
            note6.enabled = false;
            note7.enabled = false;
        }

        if (Input.GetKeyDown(note1Key))
        {
            note1.enabled = true;
        }
        else if (Input.GetKeyUp(note1Key))
        {
            note1.enabled = false;
        }

        if (Input.GetKeyDown(note2Key))
        {
            note2.enabled = true;
        }
        else if (Input.GetKeyUp(note2Key))
        {
            note2.enabled = false;
        }

        if (Input.GetKeyDown(note3Key))
        {
            note3.enabled = true;
        }
        else if (Input.GetKeyUp(note3Key))
        {
            note3.enabled = false;
        }

        if (Input.GetKeyDown(note4Key))
        {
            note4.enabled = true;
        }
        else if (Input.GetKeyUp(note4Key))
        {
            note4.enabled = false;
        }

        if (Input.GetKeyDown(note5Key))
        {
            note5.enabled = true;
        }
        else if (Input.GetKeyUp(note5Key))
        {
            note5.enabled = false;
        }

        if (Input.GetKeyDown(note6Key))
        {
            note6.enabled = true;
        }
        else if (Input.GetKeyUp(note6Key))
        {
            note6.enabled = false;
        }

        if (Input.GetKeyDown(note7Key))
        {
            note7.enabled = true;
        }
        else if (Input.GetKeyUp(note7Key))
        {
            note7.enabled = false;
        }
    }
}
