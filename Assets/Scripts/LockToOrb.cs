using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockToOrb : MonoBehaviour
{
    public float raycastDistance = 10f;  
    public Transform characterController;
    public Transform virtualCameraTransform;
    [HideInInspector] public Transform lockedTarget;

    [SerializeField] private Image lockOnCrosshair;
    [SerializeField] private Image hoverCrosshair;
    private bool isCameraLocked = false;
    private Transform _lockedTarget;
    private Ray ray;
    private RaycastHit hit;

    private void Start()
    {
        lockOnCrosshair.enabled = false;
        hoverCrosshair.enabled = false;
    }

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
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.tag == "Collectible")
            {
                isCameraLocked = true;
                _lockedTarget = hit.transform;
            }
        }

        if (_lockedTarget != null)
        {
            lockedTarget = _lockedTarget;
            lockOnCrosshair.enabled = true;
            hoverCrosshair.enabled = false;
        }
    }

    private void UnlockCamera()
    {
        isCameraLocked = false;
        _lockedTarget = null;
        lockOnCrosshair.enabled = false;
    }
}
