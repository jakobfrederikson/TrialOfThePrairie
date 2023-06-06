using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Orb_FlightPowerUp : MonoBehaviour
{
    [SerializeField] FirstPersonController firstPersonController;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered orb collider
        if (other.tag == "Player")
        {
            // Unlock sprinting for the player
            firstPersonController.flightOrbUnlocked = true;

            // Destroy the orb after collision
            Destroy(gameObject);
        }
    }
}
