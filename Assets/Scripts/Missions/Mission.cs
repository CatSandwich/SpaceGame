using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    public readonly GameObject m_UIMissionInstance;
    public readonly int m_Reward;
    private List<GameObject> m_TrackedEnemies;
     
    public Mission(GameObject uiMissionInstance, int reward, List<GameObject> enemies)
    {
        m_Reward = reward;
        m_UIMissionInstance = uiMissionInstance;
        m_TrackedEnemies = enemies;
    }

    public bool IsComplete()
    {
        return false;
        //return m_TrackedEnemies.Count == 0;
    }
}
