using UnityEngine;
using Assets.Scripts;

public class Orb_GlidePowerUp : Orb
{
    public override string Name { get; } = "Gliding";

    private void OnDestroy()
    {
        // unlock gliding for the player
        //firstPersonController.glideOrbUnlocked = true;
    }
}
