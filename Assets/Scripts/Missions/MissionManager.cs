using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager s_Instance;
    public static event Action<GameObject> a_OnEnemyDestroyed;

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
    [SerializeField] public GameObject m_EnemyShipPrefab;

    [Header("References")]
    [SerializeField] private GameObject m_MissionContent;
    [SerializeField] private GameObject m_Player;

    [Header("Config")]
    [SerializeField] private int m_NumOfMissions;
    [SerializeField] private int m_MinReward;
    [SerializeField] private int m_MaxReward;
    [SerializeField] private int m_MinEnemies;
    [SerializeField] private int m_MaxEnemies;

    [Header("Spawn Points")]
    [SerializeField] public Transform[] m_SpawnPoints;

    public List<Mission> m_Missions = new List<Mission>();
    private List<Mission> m_MissionsToRemove = new List<Mission>();

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

            if (m_Player.TryGetComponent(out Wallet wallet))
            {
                wallet.AddMoney(mission.m_Reward);
            }

            m_MissionsToRemove.Add(mission);
        }

        foreach (var mission in m_MissionsToRemove)
        {
            m_Missions.Remove(mission);
        }
    }

    private void GenerateMissions()
    {
        var missionUI = Instantiate(m_UIMissionPrefab);
        missionUI.transform.SetParent(m_MissionContent.transform, false);

        int reward = UnityEngine.Random.Range(m_MinReward, m_MaxReward + 1);

        int shipsToSpawn = UnityEngine.Random.Range(m_MinEnemies, m_MaxEnemies + 1);

        var missions = new Mission(missionUI, reward, shipsToSpawn);

        m_Missions.Add(missions);
    }

    public void RaiseOnEnemyDestroyed(GameObject go)
    {
        a_OnEnemyDestroyed(go);
    }
}
