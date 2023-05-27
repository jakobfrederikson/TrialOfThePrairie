using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToOrb : MonoBehaviour
{
    [SerializeField]
    private float dashTime = 0.3f;
    [SerializeField]
    private float dashForce = 10f;
    [SerializeField]
    private Transform virtualCameraTransform;
    private CharacterController characterController;

    private LockToOrb lockToOrbScript;

    private void Start()
    {
        lockToOrbScript = GetComponent<LockToOrb>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (lockToOrbScript.lockedTarget != null)
        {
            if (Input.GetMouseButtonDown(0))
            {          
                StartCoroutine(DashCoroutine());
            }            
        }
    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time;
        while (Time.time < startTime + dashTime && lockToOrbScript.lockedTarget != null)
        {
            // Find the direction from the orb to the players camera
            Vector3 direction = (lockToOrbScript.lockedTarget.position - virtualCameraTransform.position).normalized;

            // Apply force to the direction
            Vector3 dashVelocity = direction * dashForce;

            // Make the character move
            characterController.Move(dashVelocity * Time.deltaTime);
            yield return null;
        }
    }
}
