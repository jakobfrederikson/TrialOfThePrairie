using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToOrb : MonoBehaviour
{
    public static bool isLockedOn;

    public Transform characterController;
    public Transform virtualCameraTransform;

    private bool isCameraLocked = false;
    private Transform lockedTarget;
    private Ray ray;
    private RaycastHit hit;

    public float raycastDistance = 10f;

    private void Update()
    {
        HandleCameraLock();
    }

    private void HandleCameraLock()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            TryLockToOrb();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            UnlockCamera();
        }

        if (isCameraLocked && lockedTarget != null)
        {
            Debug.Log("Locking on to target");

            // This lets the player lock on to the target, but now it's slightly off-centre.

            // Calculate the desired look-at position
            Vector3 lookAtPosition = new Vector3(lockedTarget.position.x, characterController.transform.position.y, lockedTarget.position.z);

            // Make the character controller look at the target
            characterController.transform.LookAt(lookAtPosition);

            // Make the virtual camera transform look at the target
            virtualCameraTransform.LookAt(lockedTarget);

            //characterController.LookAt(new Vector3(lockedTarget.position.x, characterController.position.y, lockedTarget.position.z));
            //virtualCameraTransform.LookAt(lockedTarget);
        }
    }

    private void TryLockToOrb()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Collectible")
            {
                isLockedOn = true;
                isCameraLocked = true;
                lockedTarget = hit.transform;
            }
        }
    }

    private void UnlockCamera()
    {
        isLockedOn = false;
        isCameraLocked = false;
        lockedTarget = null;
    }
}
