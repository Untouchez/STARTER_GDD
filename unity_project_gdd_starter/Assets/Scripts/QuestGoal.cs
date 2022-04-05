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
        if (goalType == GoalType.Kill)
        {
            currentAmount++;
        }

        if (isReached())
        {
            GameManager.Instance.StartSecondQuest();
        }
    }
}


public enum GoalType
{
    Kill,
    Escort,
    Rescue
}