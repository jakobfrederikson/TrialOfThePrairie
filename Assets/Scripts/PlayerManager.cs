// this will be converted to the holy grail

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Quest quest;

    private void Update()
    {
        // quests
        if (quest.isActive)
        {
            quest.goal.OrbCollected();
            if (quest.goal.IsReached())
            {
                quest.Complete();
            }
        }
    }
}
