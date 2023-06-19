using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireTheSprintOrb : Quest
{
    private void Start()
    {
        Debug.Log("AcquireTheSprintOrb assigned.");
        Title = "Acquire The Sprint Orb";
        Objective = "Acquire the green orb.";
        Description = "Before you is a green orb. Walk inside of it. Give it to me, and I will give you its power.";
        RewardDescription = "You will now be able to sprint.";
        OrbReward = Assets.Scripts.OrbType.Sprint;

        Goals.Add(new OrbCollectionGoal(this, "1", Description, false, 0, 1));

        Goals.ForEach(g => g.Init());
        base.Init();
    }
}
