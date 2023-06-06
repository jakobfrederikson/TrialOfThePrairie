using Assets.Scripts;
using UnityEngine;

public class Orb_DoubleJump : Orb
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered orb collider
        if (other.tag == "Player")
        {
            // Unlock sprinting for the player
            firstPersonController.doubleJumpOrbUnlocked = true;

            // Destroy the orb after collision
            Destroy(gameObject);
        }
    }
}
