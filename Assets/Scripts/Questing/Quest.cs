using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour 
{
    public List<QuestGoal> Goals { get; set; } = new List<QuestGoal>();
    public string Title { get; set; }
    public string Objective { get; set; }
    public string Description { get; set; }
    public string RewardDescription { get; set; }
    public Orb OrbReward { get; set; }
    public bool Completed { get; set; }

    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
        if (Completed) GiveReward();
    }

    private void GiveReward()
    {
        if (OrbReward != null)
            OrbReward.GiveReward();
    }
}
