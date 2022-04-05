using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;

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
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void EndDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
