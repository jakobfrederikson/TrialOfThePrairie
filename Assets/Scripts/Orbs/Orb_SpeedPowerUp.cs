using UnityEngine;
using Assets.Scripts;
using System.Linq;

public class Orb_SpeedPowerUp : Orb
{
    public override string Name { get; } = "Speed";
    public override string ID { get; set; } = "1";
    public override OrbType OrbType { get; set; } = OrbType.Sprint;

    private void OnDestroy()
    {
    }
}
