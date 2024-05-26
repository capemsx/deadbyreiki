using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterController))]
public class PlayerWalkingSound : MonoBehaviour
{
    public AudioClip walkingClip;  // The walking audio clip
    public float walkingThreshold = 0.1f;  // Minimum speed to consider walking
    public int smoothingFrames = 5;  // Number of frames to average over

    private AudioSource audioSource;
    private CharacterController characterController;
    private float[] velocityBuffer;
    private int bufferIndex;

    void Start()
    {
        // Get the AudioSource component attached to the player GameObject
        audioSource = GetComponent<AudioSource>();

        // Get the CharacterController component attached to the player GameObject
        characterController = GetComponent<CharacterController>();

        // Assign the walking clip to the audio source
        audioSource.clip = walkingClip;

        // Make sure the audio source is not playing on start
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        // Initialize the velocity buffer
        velocityBuffer = new float[smoothingFrames];
        bufferIndex = 0;

        if (walkingClip == null)
        {
            Debug.LogError("Walking clip not assigned!");
        }

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing!");
        }

        if (characterController == null)
        {
            Debug.LogError("CharacterController component missing!");
        }
    }

    void Update()
    {
        // Add the current velocity to the buffer and advance the index
        velocityBuffer[bufferIndex] = characterController.velocity.magnitude;
        bufferIndex = (bufferIndex + 1) % smoothingFrames;

        // Calculate the average velocity over the buffer
        float averageVelocity = 0f;
        foreach (float velocity in velocityBuffer)
        {
            averageVelocity += velocity;
        }
        averageVelocity /= smoothingFrames;

        // Check if the average velocity is above the threshold
        if (averageVelocity > walkingThreshold)
        {
            // If not already playing, play the walking sound
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                //Debug.Log("Playing walking sound.");
            }
        }
        else
        {
            // If the player is not moving, stop the walking sound
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                //Debug.Log("Stopping walking sound.");
            }
        }

        //Debug.Log("Average player velocity: " + averageVelocity);
    }
}
