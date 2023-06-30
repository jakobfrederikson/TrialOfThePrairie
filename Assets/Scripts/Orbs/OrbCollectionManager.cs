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
            _onOrbDestroyText.text = $"Quest item collected";
            StopAllCoroutines();
            StartCoroutine(TextCoroutine.Instance.FadeTextToFullAlpha(_onOrbDestroyText, 1.0f));
            StartCoroutine(TextCoroutine.Instance.FadeTextToZeroAlpha(_onOrbDestroyText, 1.0f));
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
