using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _interactBox;

    private bool _playerInTrigger = false;
    private bool _isInteracting = false;
    private bool _isEnemy;

    private void Start()
    {
        _interactBox.SetActive(false);
        Debug.Log("Creating interactable: " + gameObject);
    }

    void Update()
    {
        if (_playerInTrigger && !_isInteracting)
        {
            // display key to interact
            _interactBox.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isInteracting = true;
                Interact();
            }
        }
        else if (!_isEnemy && _playerInTrigger && _isInteracting)
        {
            // stop displaying interact key when interacting
            _interactBox.SetActive(false);
        }
        else if (!_playerInTrigger)
        { 
            // player not in trigger
            _interactBox.SetActive(false);
            _isInteracting = false;
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // enable interact box
            _playerInTrigger = true;
            _isEnemy = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // disable interact box
            _playerInTrigger = false;
        }
    }
}
