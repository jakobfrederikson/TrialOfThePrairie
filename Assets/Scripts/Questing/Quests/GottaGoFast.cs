using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GottaGoFast : Quest
{
    private void Start()
    {
        Debug.Log("Gotta Go Fast assigned.");
        Title = "Gotta Go Fast";
        Objective = "Acquire the green orb.";
        Description = "Before you is a green orb. Walk inside of it. Give it to me, and I will give you its power.";
        RewardDescription = "You will now be able to sprint.";
        OrbReward = Assets.Scripts.OrbType.Sprint;

        Goals.Add(new CollectionGoal(this, "1", Description, false, 0, 1));

        Goals.ForEach(g => g.Init());
    }
}
