using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionUI : MonoBehaviour
{
    public TMP_Text m_Text;
    public Image m_Image;
    public Color m_AcceptedColor;
    private bool m_IsAccepted = false;

    private void Start()
    {
        foreach (var mission in MissionManager.s_Instance.m_Missions)
        {
            if (mission.m_UIMissionInstance == this.gameObject)
            {
                m_Text.text = $"BOUNTY MISSION \n Enemies: {mission.m_ShipsToSpawn} - Payout: ${mission.m_Reward}";
            }
        }
    }

    public void AcceptMission()
    {
        if (m_IsAccepted) return;

        foreach (var mission in MissionManager.s_Instance.m_Missions)
        {
            if (mission.m_UIMissionInstance == this.gameObject)
            {
                m_IsAccepted = true;
                m_Image.color = m_AcceptedColor;
                mission.AcceptMission();
            }
        }
    }
}
