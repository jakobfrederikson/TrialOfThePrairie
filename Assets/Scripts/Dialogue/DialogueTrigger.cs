// Dialogue Trigger for NPC and Player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private bool inTrigger;

    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TriggerDialogue();
            }                
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }                
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
}
