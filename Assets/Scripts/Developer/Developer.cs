using Assets.Scripts;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Developer : MonoBehaviour
{
    public FirstPersonController firstPersonController;

    public GameObject collectible;
    public Transform playerCameraTransform;
    private Ray ray;
    private RaycastHit hit;
    private float raycastDistance = 10f;

    // Update is called once per frame
    void Update()
    {
        // Give all power ups
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            firstPersonController.sprintOrbUnlocked = true;
            firstPersonController.doubleJumpOrbUnlocked = true;
            firstPersonController.glideOrbUnlocked = true;
            firstPersonController.lockOnOrbUnlocked = true;
        }

        // spawn collectible
        if (Input.GetKeyDown(KeyCode.F))
        {
            ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            if (Physics.Raycast(ray, out hit, raycastDistance))
                collectible.transform.position = hit.point;
            else
                collectible.transform.position = playerCameraTransform.position + ray.direction * raycastDistance;
            Instantiate(collectible);            
        }
    }
}
