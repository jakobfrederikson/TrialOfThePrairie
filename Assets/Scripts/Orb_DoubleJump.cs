using Assets.Scripts;
using UnityEngine;

public class Orb_DoubleJump : Orb
{
    private void OnDestroy()
    {
        // unlock double jump for the player
        firstPersonController.doubleJumpOrbUnlocked = true;
    }
}
