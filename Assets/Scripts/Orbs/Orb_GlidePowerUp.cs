using UnityEngine;
using Assets.Scripts;

public class Orb_GlidePowerUp : Orb
{
    public override string Name { get; } = "Gliding";
    public override string ID { get; set; } = "3";
    public override OrbType OrbType { get; set; } = OrbType.Glide;
}
