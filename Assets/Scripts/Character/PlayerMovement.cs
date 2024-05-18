using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f; // Schwerkraft
    public PlayerOrientation playerOrientation;
    private Vector3 velocity; // Geschwindigkeit aufgrund der Schwerkraft
    private bool isPlayerMovementEnabled = true; // Flag to track player movement

    void Update()
    {
        // Überprüfen, ob der Spieler am Boden ist
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Kleine Kraft nach unten, um sicherzustellen, dass der Spieler am Boden bleibt
        }

        if (isPlayerMovementEnabled)
        {

            // Bewegung des Spielers
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            // Anwendung der Schwerkraft
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            // Aktualisierung der Blickrichtung
            playerOrientation.UpdateOrientation();
        }
    }

    public void allowPlayerMovement(bool pAllowPlayerMovement)
    {
        isPlayerMovementEnabled = pAllowPlayerMovement;
    }

}
