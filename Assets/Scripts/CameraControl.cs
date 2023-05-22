using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform playerBody;
    public LayerMask collectibleLayer;
    public float lockOnRange = 10f;

    private float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Calculate vertical rotation for the camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player body horizontally based on mouse X movement
        playerBody.Rotate(Vector3.up * mouseX);
    }
}