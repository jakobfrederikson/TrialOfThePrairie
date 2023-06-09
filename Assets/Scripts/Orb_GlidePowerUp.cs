using UnityEngine;
using Assets.Scripts;

public class Orb_GlidePowerUp : Orb
{
    private void OnDestroy()
    {
        // unlock gliding for the player
        firstPersonController.glideOrbUnlocked = true;
    }
}
