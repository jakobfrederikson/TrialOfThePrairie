using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToOrb : MonoBehaviour
{
    private Rigidbody rb;
    public float dashForce = 10f;
    public Transform cameraTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (LockToOrb.isLockedOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 dashDirection = cameraTransform.forward;
                rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
            }            
        }
    }
}
