using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class AcquireTheGlideOrb : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AcquireTheGlideOrb assigned.");
        Title = "Acquire The Glide Orb";
        Objective = "Acquire the blue orb.";
        Description = "Before you is an blue orb. Walk inside of it. Give it to me, and I will give you its power.";
        RewardDescription = "You will now be able to glide.";
        OrbReward = Assets.Scripts.OrbType.Glide;

        Goals.Add(new OrbCollectionGoal(this, "3", Description, false, 0, 1));

        Goals.ForEach(g => g.Init());
        base.Init();
    }
}
