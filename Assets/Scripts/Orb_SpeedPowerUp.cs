using UnityEngine;
using Assets.Scripts;

public class Orb_SpeedPowerUp : Orb
{
    private void OnDestroy()
    {
        // unlock sprinting for the player
        firstPersonController.sprintOrbUnlocked = true;
    }
}
