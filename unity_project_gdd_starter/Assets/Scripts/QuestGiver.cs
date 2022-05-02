using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public Player player;

    public GameObject questWindow;

    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public bool hasGivenQuest;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        quest.questGiver = this;
    }

    public void openQuestWindow()
    {
        //questWindow.SetActive(true);
        //titleText.text = quest.title;
        //descriptionText.text = quest.description;

        AcceptQuest();
    }

    public void AcceptQuest()
    {
        //questWindow.SetActive(false);
        quest.isActive = true;
        //give to player
        player.quest = quest;

        GameManager.Instance.StartQuest();
    }

}
