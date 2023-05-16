using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform playerBody;
    public LayerMask collectibleLayer;
    public float lockOnRange = 10f;

    private float xRotation = 0f;
    private bool isCameraLocked = false;
    private Transform lockedTarget;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleRotation();
        HandleCameraLock();
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player body horizontally based on mouse X movement
        playerBody.Rotate(Vector3.up * mouseX);

        // Calculate vertical rotation for the camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void HandleCameraLock()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            LockOnToNearestCollectible();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            UnlockCamera();
        }

        if (isCameraLocked && lockedTarget != null)
        {
            transform.LookAt(lockedTarget);
        }
    }

    private void LockOnToNearestCollectible()
    {
        Collider[] collectibles = Physics.OverlapSphere(transform.position, lockOnRange, collectibleLayer);
        if (collectibles.Length > 0)
        {
            Transform nearestCollectible = GetNearestCollectible(collectibles);
            if (nearestCollectible != null)
            {
                isCameraLocked = true;
                lockedTarget = nearestCollectible;
            }
        }
    }

    private void UnlockCamera()
    {
        isCameraLocked = false;
        lockedTarget = null;
    }

    private Transform GetNearestCollectible(Collider[] collectibles)
    {
        Transform nearestCollectible = null;
        float nearestDistance = Mathf.Infinity;

        foreach (Collider collectible in collectibles)
        {
            float distance = Vector3.Distance(transform.position, collectible.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestCollectible = collectible.transform;
            }
        }

        return nearestCollectible;
    }
}
