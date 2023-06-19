using Assets.Scripts;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class QuestGiver : NPC
{
    [SerializeField] private FirstPersonController firstPersonController;
    public bool AssignedQuest { get; set; }

    [SerializeField]
    private GameObject quests;
    [SerializeField]
    private OrbCollectionManager orbManager;

    [SerializeField]
    private string questType;
    private Quest Quest { get; set; }

    private int _questCount = 0;

    public override void Interact()
    {
        base.Interact();
        // there's only 4 quests in the game, so don't assign a new one if they've reached that
        if (!AssignedQuest && _questCount <= 3)
        {
            AssignQuest();
        }
        else if (AssignedQuest)
        {
            CheckQuest();
        }
    }

    private void AssignQuest()
    {
        AssignedQuest = true;

        // find the correct quest to assign
        Quest = _questCount switch
        {
            0 => (Quest)quests.AddComponent(System.Type.GetType("AcquireTheSprintOrb")),
            1 => (Quest)quests.AddComponent(System.Type.GetType("AcquireTheDoubleJumpOrb")),
            2 => (Quest)quests.AddComponent(System.Type.GetType("AcquireTheGlideOrb")),
            3 => (Quest)quests.AddComponent(System.Type.GetType("AcquireTheLockOnOrb"))
        };
        Quest.firstPersonController = firstPersonController;        
    }

    private void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            AssignedQuest = false;
            DialogueManager.Instance.AddNewDialogue(new string[] { "Good job! Here's your reward.", "Come back and there might be some more quests!" }, name);
            _questCount++;

            // remove the quest from the quests object
            foreach (var component in quests.GetComponents<Component>())
            {
                if (component is not Transform)
                    Destroy(component);
            }
                
        }
        else
        {
            DialogueManager.Instance.AddNewDialogue(new string[] { "You're still in the middle of helping me. Get back to it!" }, name);
        }
    }
}
