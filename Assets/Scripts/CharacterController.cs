using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float sprintSpeedMultiplier = 1.5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isSprinting;

    public Transform movementDirectionTransform;
    public Transform cameraTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Handle player movement
        HandleMovement();

        // Handle sprinting
        HandleSprint();

        // Handle jumping
        HandleJump();
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement.Normalize(); // Ensure consistent movement speed in all directions

        // Calculate the movement direction based on the movement transform and camera's forward direction
        Vector3 moveDirection = (movementDirectionTransform.forward * movement.z + movementDirectionTransform.right * movement.x).normalized;
        moveDirection.y = 0f; // Ignore vertical movement

        // Apply movement speed
        moveDirection *= movementSpeed;

        if (isSprinting)
        {
            moveDirection *= sprintSpeedMultiplier;
        }

        // Rotate the movement direction based on the camera's forward direction
        Quaternion cameraRotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f);
        moveDirection = cameraRotation * moveDirection;

        // Move the Rigidbody
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }


    private void HandleSprint()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
