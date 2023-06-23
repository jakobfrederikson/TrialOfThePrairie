using Assets.Scripts;
using Ink.Parsed;
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
            _ => throw new System.Exception("test")
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
            StopAllCoroutines();
            StartCoroutine(FadeTextToFullAlpha());
            StartCoroutine(FadeTextToZeroAlpha());

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

    public IEnumerator FadeTextToFullAlpha()
    {
        _questRewardText.color = new Color(_questRewardText.color.r,
                                            _questRewardText.color.g,
                                            _questRewardText.color.b,
                                            0);

        while (_questRewardText.color.a < 1.0f)
        {
            _questRewardText.color = new Color(_questRewardText.color.r,
                                                _questRewardText.color.g,
                                                _questRewardText.color.b,
            _questRewardText.color.a + (Time.deltaTime / 1.0f));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha()
    {
        yield return new WaitForSeconds(2.0f);
        _questRewardText.color = new Color(_questRewardText.color.r,
                                            _questRewardText.color.g,
                                            _questRewardText.color.b,
                                            1);

        while (_questRewardText.color.a > 0.0f)
        {
            _questRewardText.color = new Color(_questRewardText.color.r,
                                                _questRewardText.color.g,
                                                _questRewardText.color.b,
            _questRewardText.color.a - (Time.deltaTime / 1.0f));
            yield return null;
        }
    }
}
