using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public GameObject dialoguePanel;
    public string npcName;
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    public TextMeshProUGUI dialogueText, nameText;
    int dialogueIndex = 0;

    [HideInInspector] public bool PlayerInDialogue { get; private set; }

    private void Awake()
    {
        PlayerInDialogue = false;

        continueButton = dialoguePanel.GetComponentInChildren<Button>();
        dialogueText = dialoguePanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        dialoguePanel.SetActive(false);

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>();
        foreach (string line in lines)
        {
            dialogueLines.Add(line);
        }
        this.npcName = npcName;

        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);

        // dialogue requires a cursor to navigate
        ShowPlayerCursor();
        PlayerInDialogue = true;
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(dialogueLines[dialogueIndex]));
        }
        else
        {
            dialoguePanel.SetActive(false);
            // once dialogue is finished, hide cursor
            HidePlayerCursor();

            PlayerInDialogue = false;
        }

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void ShowPlayerCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void HidePlayerCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
