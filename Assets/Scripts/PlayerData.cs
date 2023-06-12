using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public bool speedOrbUnlocked;
    public bool doubleJumpOrbUnocked;
    public bool glideOrbUnlocked;
    public bool lockOnOrbUnlocked;
    public float[] position; 

    public PlayerData(FirstPersonController player)
    {
        speedOrbUnlocked = player.sprintOrbUnlocked;
        doubleJumpOrbUnocked = player.doubleJumpOrbUnlocked;
        glideOrbUnlocked = player.glideOrbUnlocked;
        lockOnOrbUnlocked = player.lockOnOrbUnlocked;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
