using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public bool doneTalking;
    public Text nameText;

    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    public QuestGiver questGiver;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue, QuestGiver questGiver)
    {
        if (questGiver == null || questGiver.hasGivenQuest) return;
        
        doneTalking = false;
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name; 
        sentences.Clear();


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

       this.questGiver = questGiver;

        Update();

    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue(true);
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue(bool startQuest)
    {
        if (questGiver != null && questGiver.hasGivenQuest) return;


        animator.SetBool("isOpen", false);
        dialogueText.text = "";
        nameText.text = "";
        doneTalking = true;
        Debug.Log("End of conversation");

        if (startQuest)
         {
             questGiver.hasGivenQuest = true;
             questGiver.openQuestWindow();
         }
        if (startQuest)
        {
            GameManager.Instance.StartKeyQuest();
            GameManager.Instance.StartCagedEnemySpawnQuest();
        }
    }
}
    