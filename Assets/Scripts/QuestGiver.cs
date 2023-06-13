using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public PlayerManager player;

    public GameObject questWindow;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
    }
}
