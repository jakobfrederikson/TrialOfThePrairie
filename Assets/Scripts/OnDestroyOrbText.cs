using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnDestroyOrbText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _orbDestroyText;
    public float textFadeLength = 1.0f;

    private void Awake()
    {
        _orbDestroyText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            Debug.Log("Display Text");
        }
    }
}
