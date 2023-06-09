using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrbCollectionManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _onOrbDestroyText;
    public float transparencyDelay = 1.0f;

    private void Start()
    {
        _onOrbDestroyText.enabled = false;
        _onOrbDestroyText.alpha = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            StartCoroutine(ShowMessage());
        }
    }

    IEnumerator ShowMessage()
    {
        float startTime = Time.time;
        _onOrbDestroyText.enabled = true;
        while (Time.time < startTime + transparencyDelay)
        {
            _onOrbDestroyText.alpha += 1.0f;
            yield return null;
        }            
        
        yield return new WaitForSeconds(transparencyDelay);
        _onOrbDestroyText.enabled = false;

        startTime = Time.time;
        while (Time.time < startTime + transparencyDelay)
        {
            _onOrbDestroyText.alpha -= 1.0f;
            yield return null;
        }
    }
}
