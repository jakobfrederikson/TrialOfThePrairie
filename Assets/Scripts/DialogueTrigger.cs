using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private BoxCollider boxCollider;
    private bool inTrigger;
    private bool isPlayer;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
                TriggerDialogue();
            if (Input.GetKeyDown(KeyCode.Q))
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
        isPlayer = other.tag == "Player" ? true : false;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        isPlayer = other.tag == "Player" ? true : false;
    }
}
