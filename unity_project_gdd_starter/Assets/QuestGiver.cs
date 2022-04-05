using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public GameObject questWindow;
    public DialogueManager dialogueManager;

    public TMP_Text titleText;
    public TMP_Text descriptionText;

    private void OnTriggerEnter(Collider other)
    {
        openQuestWindow();
    }
    public void openQuestWindow()
    {
        if (dialogueManager.doneTalking)
        {
            questWindow.SetActive(true);
            titleText.text = quest.title;
            descriptionText.text = quest.description;
            Debug.Log("Open questWindow()");
        }
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        // give quest to player
    }
}
