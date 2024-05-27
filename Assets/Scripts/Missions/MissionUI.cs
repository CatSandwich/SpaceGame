using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionUI : MonoBehaviour
{
    private bool m_IsAccepted = false;
    public void AcceptMission()
    {
        if (m_IsAccepted) return;

        foreach (var mission in MissionManager.s_Instance.m_Missions)
        {
            if (mission.m_UIMissionInstance == this.gameObject)
            {
                m_IsAccepted = true;
                mission.AcceptMission();
            }
        }
    }
}
