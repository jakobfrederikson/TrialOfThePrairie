using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string objective;
    public string description;
    public string rewardDescription;

    public QuestGoal goal;
}
