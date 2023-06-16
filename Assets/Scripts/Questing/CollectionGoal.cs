using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : QuestGoal
{
    public string ItemID { get; set; }

    public CollectionGoal(Quest quest, string itemID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemID = itemID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
    }

    public void ItemPickedUp (Orb orb)
    {
        if (orb.ID == this.ItemID)
        {
            Debug.Log("Detected orb: " + ItemID);
            this.CurrentAmount++;
            Evaluate();
        }
    }
}
