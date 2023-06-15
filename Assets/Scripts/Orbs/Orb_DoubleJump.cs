using Assets.Scripts;
using UnityEngine;

public class Orb_DoubleJump : Orb
{
    public override string Name { get; } = "Double Jump";

    private void OnDestroy()
    {
        // unlock double jump for the player
        firstPersonController.doubleJumpOrbUnlocked = true;
    }
}
