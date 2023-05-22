using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToOrb : MonoBehaviour
{
    private bool isMouse1Down = false;
    private bool isCameraLocked = false;
    private Transform lockedTarget;
    private Quaternion targetRotation; 
    
    public float raycastDistance = 10f;

    private void Update()
    {
        HandleCameraLock();

        if (isMouse1Down == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        }
    }

    private void HandleCameraLock()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            LockOnToNearestCollectible();
            isMouse1Down = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            UnlockCamera();
            isMouse1Down = false;
        }

        if (isCameraLocked && lockedTarget != null)
        {
            transform.LookAt(lockedTarget);
        }
    }

    private void LockOnToNearestCollectible()
    {
        

        //Collider[] collectibles = Physics.OverlapSphere(transform.position, lockOnRange, collectibleLayer);
        //if (collectibles.Length > 0)
        //{
        //    Transform nearestCollectible = GetNearestCollectible(collectibles);
        //    if (nearestCollectible != null)
        //    {
        //        isCameraLocked = true;
        //        lockedTarget = nearestCollectible;
        //    }
        //}
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
