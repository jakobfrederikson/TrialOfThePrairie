using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    [Header("First Person Controller")]
    public FirstPersonController firstPersonController;

    [Header("Time of movement boost")]
    public float boostLength;

    [Header("Collectible Text")]
    public TextMeshProUGUI collectibleText;
    public float transparencyDelay = 1.0f;

    

    Coroutine lastPlayerBoostRoutine = null;
    Coroutine lastTextUpdateRoutine1 = null;
    Coroutine lastTextUpdateRoutine2 = null;

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

    private void Start()
    {
        collectibleText.color = new Color(collectibleText.color.r,
                                          collectibleText.color.g,
                                          collectibleText.color.b,
                                          0);
    }

    public void AcquiredCollectible()
    {
        // make sure player has the correct orb unlocked
        if (firstPersonController.lockOnOrbUnlocked)
        {
            Debug.Log("Acquired collectible. Boosting stats.");
            BoostPlayerStats();
            UpdateCollectibleText();
        }
    }

    private void BoostPlayerStats()
    {
        if (lastPlayerBoostRoutine != null)
        {
            StopCoroutine(lastPlayerBoostRoutine);
        }
        
        PlayerManager.Instance.CollectibleBalance++;

        firstPersonController.Gravity = 0;
        firstPersonController.GlideSpeed = 0;
        firstPersonController.MoveSpeed += 5;
        firstPersonController.SprintSpeed += 5;

        lastPlayerBoostRoutine = StartCoroutine(ResetStats());
    }

    private void UpdateCollectibleText()
    {
        if (lastTextUpdateRoutine1 != null &&
            lastTextUpdateRoutine2 != null)
        {
            StopCoroutine(lastTextUpdateRoutine1);
            StopCoroutine(lastTextUpdateRoutine2);
        }
        
        collectibleText.text = PlayerManager.Instance.CollectibleBalance.ToString();

        lastTextUpdateRoutine1 = StartCoroutine(FadeTextToFullAlpha());
        lastTextUpdateRoutine2 = StartCoroutine(FadeTextToZeroAlpha());
    }

    private IEnumerator ResetStats()
    {
        yield return new WaitForSeconds(boostLength);

        // reset controller using initial values
        firstPersonController.Gravity = PlayerManager.Instance.Gravity;
        firstPersonController.GlideSpeed = PlayerManager.Instance.GlideSpeed;
        firstPersonController.MoveSpeed = PlayerManager.Instance.Speed;
        firstPersonController.SprintSpeed = PlayerManager.Instance.SprintSpeed;

        yield return null;
    }

    public IEnumerator FadeTextToFullAlpha()
    {
        collectibleText.color = new Color(collectibleText.color.r,
                                            collectibleText.color.g,
                                            collectibleText.color.b,
                                            0);

        while (collectibleText.color.a < 1.0f)
        {
            collectibleText.color = new Color(collectibleText.color.r,
                                                collectibleText.color.g,
                                                collectibleText.color.b,
            collectibleText.color.a + (Time.deltaTime / transparencyDelay));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha()
    {
        yield return new WaitForSeconds(2.0f);
        collectibleText.color = new Color(collectibleText.color.r,
                                            collectibleText.color.g,
                                            collectibleText.color.b,
                                            1);

        while (collectibleText.color.a > 0.0f)
        {
            collectibleText.color = new Color(collectibleText.color.r,
                                                collectibleText.color.g,
                                                collectibleText.color.b,
            collectibleText.color.a - (Time.deltaTime / transparencyDelay));
            yield return null;
        }
    }
}
