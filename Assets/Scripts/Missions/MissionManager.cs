using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager s_Instance;

    public static MissionManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                Debug.LogError("MissionManager is null");
            }
            return s_Instance;
        }
    }

    [Header("Prefabs")]
    [SerializeField] private GameObject m_UIMissionPrefab;
    [SerializeField] private GameObject m_EnemyShipPrefab;

    [Header("References")]
    [SerializeField] private GameObject m_MissionContent;

    [Header("Config")]
    [SerializeField] private int m_NumOfMissions;
    [SerializeField] private int m_MinReward;
    [SerializeField] private int m_MaxReward;
    [SerializeField] private int m_MinEnemies;
    [SerializeField] private int m_MaxEnemies;

    [Header("Spawn Points")]
    [SerializeField] private Transform[] m_SpawnPoints;

    // Private
    private List<Mission> m_Missions = new List<Mission>();

    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else if (s_Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (m_Missions.Count < m_NumOfMissions) GenerateMissions();

        foreach (var mission in m_Missions)
        {
            if (!mission.IsComplete()) continue;

            m_Missions.Remove(mission);
        }
    }

    private void GenerateMissions()
    {
        var missionUI = Instantiate(m_UIMissionPrefab);
        missionUI.transform.SetParent(m_MissionContent.transform, false);

        int reward = UnityEngine.Random.Range(m_MinReward, m_MaxReward + 1);

        List<GameObject> ships = new();

        var missions = new Mission(missionUI, reward, ships);

        m_Missions.Add(missions);
    }
}
