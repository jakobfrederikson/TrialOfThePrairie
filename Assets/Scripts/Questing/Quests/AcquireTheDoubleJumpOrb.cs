using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcquireTheDoubleJumpOrb : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AcquireTheDoubleJumpOrb assigned.");
        Title = "Acquire The Double Jump Orb";
        Objective = "Acquire the orange orb.";
        Description = "Before you is an orange orb. Walk inside of it. Give it to me, and I will give you its power.";
        RewardDescription = "You will now be able to double jump.";
        OrbReward = Assets.Scripts.OrbType.DoubleJump;

        Goals.Add(new OrbCollectionGoal(this, "2", Description, false, 0, 1));

        Goals.ForEach(g => g.Init());
        base.Init();
    }

    public override string[] StartQuestDialogue()
    {
        return new string[] {
                              "Great job on your last quest. You did a task, and you grew as a person.",
                              "At least, that's one way to think of it.",
                              "Here's a clue about your next quest... it will HELP you reach new heights!",
                              "You're going to have to do some exploration to find this orb. Good luck!"
                            };
    }

    public override string[] CompleteQuestDialogue()
    {
        return new string[] { "You can now double jump.",
        "Press your jump button again after the first time to execute this power!"};
    }
}
