using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_LockOn : Orb
{
    [SerializeField] private LockToOrb _lockToOrb;

    public override string Name { get; } = "Lock On";

    private void OnDestroy()
    {
        firstPersonController.lockOnOrbUnlocked = true;
        _lockToOrb.lockOnOrbUnlocked = true;
    }
}
