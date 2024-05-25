using UnityEngine;

public class LookAtTransparency : MonoBehaviour
{
    public Camera playerCamera;  // Reference to the player's camera
    public GameObject targetObject;  // The object that will become transparent
    public float transparencySpeed = 1f;  // Speed at which the object becomes transparent
    public float transparencyThreshold = 0.1f;  // The transparency threshold to disable the collider
    public ItemPickup itemPickup;
    public GameObject deskLamp;

    private Renderer targetRenderer;
    private Collider targetCollider;
    private Material targetMaterial;
    private Color originalColor;
    private float cooldownTimer = 0f;
    private const float inputCooldown = 10f; // Cooldown period in seconds
    public bool isTransparent = false;

    void Start()
    {
        // Initialize references
        if (targetObject != null)
        {
            targetRenderer = targetObject.GetComponent<Renderer>();
            targetCollider = targetObject.GetComponent<Collider>();

            if (targetRenderer != null)
            {
                targetMaterial = targetRenderer.material;

                // Ensure the material is set to transparent mode
                targetMaterial.SetFloat("_Mode", 3);  // 3 corresponds to transparent mode
                targetMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                targetMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                targetMaterial.SetInt("_ZWrite", 0);
                targetMaterial.DisableKeyword("_ALPHATEST_ON");
                targetMaterial.EnableKeyword("_ALPHABLEND_ON");
                targetMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                targetMaterial.renderQueue = 3000;

                originalColor = targetMaterial.color;
            }
            else
            {
                Debug.LogError("Target object does not have a Renderer component.");
            }

            if (targetCollider == null)
            {
                Debug.LogError("Target object does not have a Collider component.");
            }

            if (targetMaterial == null)
            {
                Debug.LogError("Target object's material is null or not properly assigned.");
            }
        }
        else
        {
            Debug.LogError("Target object is not assigned.");
        }

        if (playerCamera == null)
        {
            Debug.LogError("Player camera is not assigned.");
        }
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
        // Check if the player is looking at the object
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5) && itemPickup.getInventory() == deskLamp)
        {
            if (hit.transform == targetObject.transform)
            {
                // Gradually make the object transparent
                Color newColor = targetMaterial.color;
                newColor.a -= transparencySpeed * Time.deltaTime;
                newColor.a = Mathf.Clamp(newColor.a, transparencyThreshold, originalColor.a);
                targetMaterial.color = newColor;

                if (newColor.a <= transparencyThreshold && !isTransparent)
                {
                    // Disable the collider when transparency threshold is reached
                    targetCollider.enabled = false;
                    targetObject.SetActive(false);
                    isTransparent = true;
                }
                cooldownTimer = 0f;
            }
        }
        else if (isTransparent && (cooldownTimer >= inputCooldown))
        {
            // Gradually make the object opaque again if the player is not looking at it
            Color newColor = targetMaterial.color;
            newColor.a += transparencySpeed * Time.deltaTime;
            newColor.a = Mathf.Clamp(newColor.a, transparencyThreshold, originalColor.a);
            targetMaterial.color = newColor;

            if (newColor.a >= originalColor.a)
            {
                // Enable the collider when the object is fully opaque
                targetCollider.enabled = true;
                targetObject.SetActive(true);
                isTransparent = false;
            }
        }

    }
}
