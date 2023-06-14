using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void OrbCollected()
    {
        if (goalType == GoalType.Collect)
            currentAmount++;
    }

    public void AreaDiscovered()
    {
        if (goalType == GoalType.Discover)
            currentAmount++;
    }
}

public enum GoalType
{
    Collect,
    Discover
}