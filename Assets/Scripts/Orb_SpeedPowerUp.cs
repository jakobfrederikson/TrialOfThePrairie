using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Orb_SpeedPowerUp : MonoBehaviour
{
    [SerializeField] FirstPersonController firstPersonController;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered orb collider
        if (other.tag == "Player")
        {
            // Unlock sprinting for the player
            firstPersonController.groundOrbUnlocked = true;

            // Destroy the orb after collision
            Destroy(this);
        }
    }
}
