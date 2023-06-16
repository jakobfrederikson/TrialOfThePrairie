using Assets.Scripts;
using UnityEngine;

public class Orb_DoubleJump : Orb
{
    public override string Name { get; } = "Double Jump";
    public override string ID { get; set; } = "2";
    public override OrbType OrbType { get; set; } = OrbType.DoubleJump;
}
