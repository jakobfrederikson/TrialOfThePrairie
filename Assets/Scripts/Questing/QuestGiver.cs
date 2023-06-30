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

    [SerializeField] private GameObject quests;
    [SerializeField] private OrbCollectionManager orbManager;

    private Quest Quest { get; set; }

    private int _questCount = 0;

    [SerializeField] private TextMeshProUGUI _questRewardText;

    private Coroutine lastTextUpdateRoutine1 = null;
    private Coroutine lastTextUpdateRoutine2 = null;

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
            3 => (Quest)quests.AddComponent(System.Type.GetType("AcquireTheLockOnOrb")),
            _ => throw new System.NotImplementedException("No more quests can be found.")
        };
        DialogueManager.Instance.AddNewDialogue(Quest.StartQuestDialogue(), name);
        Quest.firstPersonController = firstPersonController;        
    }

    private void CheckQuest()
    {
        if (Quest.Completed)
        {
            // show {name} orb unlocked message
            _questRewardText.text = $"{Quest.OrbReward} orb unlocked";

            if (lastTextUpdateRoutine1 != null &&
            lastTextUpdateRoutine2 != null)
            {
                StopCoroutine(lastTextUpdateRoutine1);
                StopCoroutine(lastTextUpdateRoutine2);
            }

            lastTextUpdateRoutine1 = StartCoroutine(TextCoroutine.Instance.FadeTextToFullAlpha(_questRewardText, 1.5f));
            lastTextUpdateRoutine2 = StartCoroutine(TextCoroutine.Instance.FadeTextToZeroAlpha(_questRewardText, 1.5f));

            Quest.GiveReward();
            AssignedQuest = false;
            DialogueManager.Instance.AddNewDialogue(Quest.CompleteQuestDialogue(), name);
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
