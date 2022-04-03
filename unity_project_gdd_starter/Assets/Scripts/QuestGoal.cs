using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool isReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if (goalType.Equals(GoalType.Kill))
        {
            currentAmount++;
        }
    }

    public void ItemGathered()
    {
        if (goalType.Equals(GoalType.Gathering))
        {
            currentAmount++;
        }
    }
}


public enum GoalType
{
    Kill,
    Gathering,
    Escorting,
}