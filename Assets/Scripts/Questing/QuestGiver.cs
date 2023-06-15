using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public PlayerManager player;

    public GameObject questWindow;
    public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questObjective;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI questReward;

    [HideInInspector]
    public bool playerOpenWindow = false;

    public void OpenQuestWindow()
    {
        playerOpenWindow = true;

        Cursor.visible = true;
        questWindow.SetActive(true);
        questTitle.text = quest.Title;
        questObjective.text = quest.Objective;
        questDescription.text = quest.Description;
        questReward.text = quest.RewardDescription;
    }

    public void CloseQuestWindow()
    {
        playerOpenWindow = false;

        Cursor.visible = false;
        questWindow.SetActive(false);
    }

    public void AcceptQuest()
    {
        CloseQuestWindow();
        quest.IsActive = true;

        player.quest = quest;
    }
}
