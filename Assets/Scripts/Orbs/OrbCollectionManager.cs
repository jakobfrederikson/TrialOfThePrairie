using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Assets.Scripts;

public class OrbCollectionManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _onOrbDestroyText;
    public float transparencyDelay = 1.0f;

    [HideInInspector] public Quest quest;

    private void Awake()
    {
        _onOrbDestroyText.color = new Color(_onOrbDestroyText.color.r,
                                            _onOrbDestroyText.color.g,
                                            _onOrbDestroyText.color.b,
                                            0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Orb")
        {                
            // if this orb is the players current quest reward
            if (other.GetComponent<Orb>().OrbType == quest.OrbReward)
            {
                quest.Goals[0].CurrentAmount++;
                quest.Goals[0].Evaluate();
            }
            _onOrbDestroyText.text = $"{other.GetComponent<Orb>().Name} orb unlocked";
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

    public void UpdateQuest(Quest newQuest)
    {
        quest = newQuest;
    }

    public void HideColliderBlocker(Quest newQuest)
    {
        quest = newQuest;

        switch (quest.OrbReward)
        {
            case OrbType.Sprint:
                FindObjectOfType<Orb_SpeedPowerUp>().transform.GetChild(5).gameObject.SetActive(false);
                break;
            case OrbType.DoubleJump:
                FindObjectOfType<Orb_DoubleJump>().transform.GetChild(5).gameObject.SetActive(false);
                break;
            case OrbType.Glide:
                FindObjectOfType<Orb_GlidePowerUp>().transform.GetChild(5).gameObject.SetActive(false);
                break;
            case OrbType.LockOn:
                FindObjectOfType<Orb_LockOn>().transform.GetChild(5).gameObject.SetActive(false);
                break;
            default:
                Debug.LogWarning("There is no orb reward");
                break;
        }
    }
}
