using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb_LockOn : Orb
{
    [SerializeField] private LockToOrb _lockToOrb;

    public override string Name { get; } = "Lock On";
    public override string ID { get; set; } = "4";
    public override OrbType OrbType { get; set; } = OrbType.LockOn;

    private void OnDestroy()
    {
        _lockToOrb.lockOnOrbUnlocked = true;
    }
}
