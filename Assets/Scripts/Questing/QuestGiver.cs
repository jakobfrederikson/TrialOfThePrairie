using Assets.Scripts;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestGiver : NPC
{
    [SerializeField] private FirstPersonController firstPersonController;
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }

    [SerializeField]
    private GameObject quests;
    [SerializeField]
    private OrbCollectionManager orbManager;

    [SerializeField]
    private string questType;
    private Quest Quest { get; set; }

    public override void Interact()
    {
        base.Interact();
        if (!AssignedQuest && !Helped)
        {
            AssignQuest();
        }
        else if (AssignedQuest && !Helped)
        {
            CheckQuest();
        }
    }

    private void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType("GottaGoFast"));
        Quest.firstPersonController = firstPersonController;
        orbManager.quest = Quest;
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueManager.Instance.AddNewDialogue(new string[] { "Good job! Here's your reward.", "More dialogue" }, name);
        }
        else
        {
            DialogueManager.Instance.AddNewDialogue(new string[] { "You're still in the middle of helping me. Get back to it!" }, name);
        }
    }
}
