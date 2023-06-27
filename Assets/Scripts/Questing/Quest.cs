using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using StarterAssets;

public class Quest : MonoBehaviour 
{
    public FirstPersonController firstPersonController { get; set; }
    public List<QuestGoal> Goals { get; set; } = new List<QuestGoal>();
    public string Title { get; set; }
    public string Objective { get; set; }
    public string Description { get; set; }
    public string RewardDescription { get; set; }
    public OrbType OrbReward { get; set; }
    public bool Completed { get; set; }
    public bool IsActive { get; set; }

    private OrbCollectionManager _orbCollectionManager;

    public void Init()
    {
        _orbCollectionManager = FindObjectOfType<OrbCollectionManager>();
        _orbCollectionManager.HideColliderBlocker(this);
    }

    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
    }

    public void GiveReward()
    {
        if (Completed)
        {
            UnlockPower();
            Debug.Log("Giving reward");
            IsActive = false;
        }            
    }

    public void UnlockPower()
    {
        switch (OrbReward)
        {
            case OrbType.Sprint:
                firstPersonController.sprintOrbUnlocked = true;
                break;
            case OrbType.DoubleJump:
                firstPersonController.doubleJumpOrbUnlocked = true;
                break;
            case OrbType.Glide:
                firstPersonController.glideOrbUnlocked = true;
                break;
            case OrbType.LockOn:
                firstPersonController.lockOnOrbUnlocked = true;
                break;
            default:
                // do nothing
                break;
        }
    }

    public virtual string[] StartQuestDialogue()
    {
       return new string[] { "Dialogue from the base class." };
    }

    public virtual string[] CompleteQuestDialogue()
    {
        return new string[] { "Dialogue from the base class."};
    }
}
