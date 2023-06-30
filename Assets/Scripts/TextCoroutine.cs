using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextCoroutine : MonoBehaviour
{
    public static TextCoroutine Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public IEnumerator FadeTextToFullAlpha(TextMeshProUGUI text, float transparencyDelay)
    {
        text.color = new Color(text.color.r,
                               text.color.g,
                               text.color.b,
                               0);

        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r,
                                   text.color.g,
                                   text.color.b,
            text.color.a + (Time.deltaTime / transparencyDelay));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(TextMeshProUGUI text, float transparencyDelay)
    {
        yield return new WaitForSeconds(2.0f);
        text.color = new Color(text.color.r,
                               text.color.g,
                               text.color.b,
                               1);

        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r,
                                   text.color.g,
                                   text.color.b,
            text.color.a - (Time.deltaTime / transparencyDelay));
            yield return null;
        }
    }
}
