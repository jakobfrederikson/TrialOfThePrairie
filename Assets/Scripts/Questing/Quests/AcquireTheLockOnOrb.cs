using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Assets.Scripts;
using UnityEditor;
using UnityEngine;

public class AcquireTheLockOnOrb : Quest
{
    void Start()
    {
        Debug.Log("AcquireTheLockOnOrb assigned.");
        Title = "Acquire The Lock On Orb";
        Objective = "Acquire the purple orb.";
        Description = "Before you is an purple orb. Walk inside of it. Give it to me, and I will give you its power.";
        RewardDescription = "You will now be able to lock on to mini orbs.";
        OrbReward = Assets.Scripts.OrbType.LockOn;

        Goals.Add(new OrbCollectionGoal(this, "4", Description, false, 0, 1));

        Goals.ForEach(g => g.Init());
        base.Init();
    }

    public override string[] StartQuestDialogue()
    {
        return new string[] {
                              "I hope you're having fun with your new gliding ability.",
                              "You may have noticed some more opaque, smaller orbs around this area.",
                              "I'm going to help you collect these, with a new power!",
                              "Head towards the ladder, and start climbing. I'll talk to you more once we're there.",
                            };
    }

    public override string[] CompleteQuestDialogue()
    {
        return new string[] { "Great job! Make sure to read this next dialogue!",
        "Press F to spawn a collectible orb in front of you.",
        "Now, with the lock on orb acquired, press right click to lock on to the orb.",
        "Then, press the left click to dash into the orb!" };
    }
}
