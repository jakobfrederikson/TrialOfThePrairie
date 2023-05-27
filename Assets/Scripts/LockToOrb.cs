using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToOrb : MonoBehaviour
{
    public static bool isLockedOn;

    public Transform capsuleTransform;
    public Transform mainCamera;
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
            Vector3 eulerRotation = lockedTarget.eulerAngles;
            eulerRotation.x = 0f;
            eulerRotation.y = 0f;
            capsuleTransform.rotation = Quaternion.Euler(eulerRotation);
            virtualCameraTransform.LookAt(lockedTarget);
            mainCamera = virtualCameraTransform;
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
