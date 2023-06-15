using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairHoverOverOrb : MonoBehaviour
{
    [SerializeField] private Image hoverOverOrbCrosshair;
    public float raycastDistance = 10f;

    private LockToOrb lockToOrbScript;
    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        lockToOrbScript = GetComponent<LockToOrb>();
        hoverOverOrbCrosshair.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lockToOrbScript.lockOnOrbUnlocked)
            CheckHover();
    }

    void CheckHover()
    {
        // Shoot out a raycast 
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.red);

        // Enable the hover crosshair if player is mousing over an orb
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.tag == "Collectible" && lockToOrbScript.lockedTarget == null)
                hoverOverOrbCrosshair.enabled = true;
        }
        else
            hoverOverOrbCrosshair.enabled = false;
    }
}
