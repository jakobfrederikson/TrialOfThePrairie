using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public Quest Quest { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }

    public virtual void Init()
    {
        // default init stuff
    }

    public void Evaluate()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }
    
    public void Complete()
    {
        Completed = true;
        this.Quest.CheckGoals();        
        Debug.Log("Goal marked as complete");
    }
}