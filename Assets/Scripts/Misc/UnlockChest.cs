using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChest : MonoBehaviour
{
    public GameObject itemToHide;
    public GameObject audioSourceObject;
    public AudioClip unlockSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = audioSourceObject.GetComponent<AudioSource>();
    }

    public void unlock()
    {
        audioSource.clip = unlockSound;
        audioSource.Play();
        itemToHide.SetActive(false);
    }
}
