using UnityEngine;
using Assets.Scripts;

public class Orb_SpeedPowerUp : Orb
{
    public override string Name { get; } = "Speed";

    private void OnDestroy()
    {
        // unlock sprinting for the player
        firstPersonController.sprintOrbUnlocked = true;
    }
}
