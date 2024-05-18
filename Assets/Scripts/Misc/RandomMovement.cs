using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 5f;
    public float changeDirectionInterval = 4f;
    public float detectionDistance = 1f;
    public float rotationSpeed = 5f;

    private Vector3 movementDirection;
    private float timeSinceLastChange;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent rotation due to physics collisions
        ChangeDirection();
    }

    void Update()
    {
        timeSinceLastChange += Time.deltaTime;

        if (timeSinceLastChange >= changeDirectionInterval || IsObstacleAhead())
        {
            ChangeDirection();
        }

        MoveRat();
    }

    void MoveRat()
    {
        if (!IsObstacleAhead())
        {
            Vector3 newPosition = rb.position + movementDirection * speed * Time.deltaTime;
            rb.MovePosition(newPosition);
        }

        RotateRat();
    }

    void ChangeDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        movementDirection = new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)).normalized;
        timeSinceLastChange = 0f;
    }

    void RotateRat()
    {
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            toRotation *= Quaternion.Euler(0, -90, 0);
            rb.rotation = Quaternion.Slerp(rb.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    bool IsObstacleAhead()
    {
        return Physics.Raycast(transform.position, movementDirection, detectionDistance);
    }
}
