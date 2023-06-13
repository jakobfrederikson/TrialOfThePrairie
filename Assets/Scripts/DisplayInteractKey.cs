using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInteractKey : MonoBehaviour
{
    [SerializeField] private GameObject _interactBox;
    private bool _playerInTrigger = false;
    private bool _playerCurrentlyInteracting = false;

    private void Start()
    {
        _interactBox.SetActive(false);
    }

    private void Update()
    {
        if (_playerInTrigger && !_playerCurrentlyInteracting)
        {
            _interactBox.SetActive(true);

            // disable interact tool tip if player starts interacting
            if (Input.GetKeyDown(KeyCode.E))
            {
                _playerCurrentlyInteracting = true;
            }
        }
        else
        {
            _interactBox.SetActive(false);
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
            // player is not interacting if they left the trigger box
            if (_playerCurrentlyInteracting) _playerCurrentlyInteracting = false;

            // disable interact box
            _playerInTrigger = false;
        }
    }
}
