using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrbCollectionManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _onOrbDestroyText;
    public float transparencyDelay = 1.0f;

    private void Awake()
    {
        _onOrbDestroyText.color = new Color(_onOrbDestroyText.color.r,
                                            _onOrbDestroyText.color.g,
                                            _onOrbDestroyText.color.b,
                                            0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            StopAllCoroutines();
            StartCoroutine(FadeTextToFullAlpha());
            StartCoroutine(FadeTextToZeroAlpha());
        }
    }

    public IEnumerator FadeTextToFullAlpha()
    {
        _onOrbDestroyText.color = new Color(_onOrbDestroyText.color.r,
                                            _onOrbDestroyText.color.g, 
                                            _onOrbDestroyText.color.b, 
                                            0);

        while (_onOrbDestroyText.color.a < 1.0f)
        {
            _onOrbDestroyText.color = new Color(_onOrbDestroyText.color.r, 
                                                _onOrbDestroyText.color.g, 
                                                _onOrbDestroyText.color.b, 
            _onOrbDestroyText.color.a + (Time.deltaTime / transparencyDelay));
            yield return null;
        } 
    }

    public IEnumerator FadeTextToZeroAlpha()
    {
        yield return new WaitForSeconds(2.0f);
        _onOrbDestroyText.color = new Color(_onOrbDestroyText.color.r,
                                            _onOrbDestroyText.color.g,
                                            _onOrbDestroyText.color.b,
                                            1);

        while (_onOrbDestroyText.color.a > 0.0f)
        {
            _onOrbDestroyText.color = new Color(_onOrbDestroyText.color.r,
                                                _onOrbDestroyText.color.g,
                                                _onOrbDestroyText.color.b,
            _onOrbDestroyText.color.a - (Time.deltaTime / transparencyDelay));
            yield return null;
        }
    }
}
