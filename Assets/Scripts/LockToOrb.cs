using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToOrb : MonoBehaviour
{
    public static bool isLockedOn;

    public Transform characterController;
    public Transform virtualCameraTransform;

    private bool isCameraLocked = false;
    private Transform _lockedTarget;
    [HideInInspector]
    public Transform lockedTarget;
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

            if (_lockedTarget == null)
            {
                lockedTarget = null;
            }
        }

        if (isCameraLocked && _lockedTarget != null)
        {
            // Calculate the desired look-at position
            Vector3 lookAtPosition = new Vector3(_lockedTarget.position.x, characterController.transform.position.y, _lockedTarget.position.z);

            // Make the character controller look at the target
            characterController.transform.LookAt(lookAtPosition);

            // Make the virtual camera transform look at the target
            virtualCameraTransform.LookAt(_lockedTarget);
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
                _lockedTarget = hit.transform;
            }
        }

        if (_lockedTarget != null)
        {
            lockedTarget = _lockedTarget;
        }
    }

    private void UnlockCamera()
    {
        isLockedOn = false;
        isCameraLocked = false;
        _lockedTarget = null;
    }
}
