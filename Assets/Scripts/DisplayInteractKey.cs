using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInteractKey : MonoBehaviour
{
    [HideInInspector] public bool PlayerCurrentlyInteracting { get; private set; } = false;

    [SerializeField] private GameObject _interactBox;
    
    [SerializeField] private QuestGiver _questGiver;

    private bool _playerInTrigger = false;

    private void Start()
    {
        _interactBox.SetActive(false);
    }

    private void Update()
    {
        if (_playerInTrigger && !PlayerCurrentlyInteracting)
        {
            _interactBox.SetActive(true);

            // disable interact tool tip if player starts interacting
            if (Input.GetKeyDown(KeyCode.E))
            {
                LockPlayerCursor();
                _interactBox.SetActive(false);
                _questGiver.OpenQuestWindow();
            }
        }
        else if (!_playerInTrigger)
        {
            UnlockPlayerCursor();
            _interactBox.SetActive(false);
            _questGiver.CloseQuestWindow();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InteractableCollider"))
        {
            // enable interact box
            _playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractableCollider"))
        {
            // disable interact box
            _playerInTrigger = false;
        }
    }

    private void LockPlayerCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerCurrentlyInteracting = true;
    }

    public void UnlockPlayerCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCurrentlyInteracting = false;
    }
}
