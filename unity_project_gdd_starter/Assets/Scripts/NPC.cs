using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;

    private QuestGiver questGiver;

    private void Start()
    {
        questGiver = GetComponent<QuestGiver>();
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerDialogue();
    }

    private void OnTriggerExit(Collider other)
    {
        EndDialogue();
    }

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, questGiver);
    }

    public void EndDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue(false);
    }
}
