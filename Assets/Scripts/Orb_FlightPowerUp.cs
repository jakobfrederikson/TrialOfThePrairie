using UnityEngine;
using Assets.Scripts;

public class Orb_FlightPowerUp : Orb
{
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
