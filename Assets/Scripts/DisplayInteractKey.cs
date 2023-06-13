using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInteractKey : MonoBehaviour
{
    [SerializeField] private Image _interactBox;
    [SerializeField] private TextMeshProUGUI _interactText;
    private bool _playerInTrigger = false;
    private bool _playerCurrentlyInteracting = false;

    private void Start()
    {
        _interactBox.enabled = false;
        _interactText.enabled = false;
    }

    private void Update()
    {
        if (_playerInTrigger && !_playerCurrentlyInteracting)
        {
            _interactBox.enabled = true;
            _interactText.enabled = true;
        }
        else
        {
            _interactBox.enabled = false;
            _interactText.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInTrigger = false;
        }
    }
}
