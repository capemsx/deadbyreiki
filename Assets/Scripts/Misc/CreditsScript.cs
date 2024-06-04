using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public float speed = 100f; // Speed at which the UI object will move upwards
    public float duration = 2f; // Duration for which the UI object will move upwards

    private RectTransform rectTransform;
    private float elapsedTime = 0f;
    private bool isMoving = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("MoveUIObjectUpwards script requires a RectTransform component on the same GameObject.");
        }
        StartMoving();
    }

    void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime < duration)
            {
                rectTransform.anchoredPosition += Vector2.up * speed * Time.deltaTime;
            }
            else
            {
                isMoving = false;
            }
        }
    }

    public void StartMoving()
    {
        elapsedTime = 0f;
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}
