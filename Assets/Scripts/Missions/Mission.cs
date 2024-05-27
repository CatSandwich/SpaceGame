using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    public readonly GameObject m_UIMissionInstance;
    public readonly int m_Reward;
    private List<GameObject> m_TrackedEnemies;
    private bool m_IsAccepted = false;
    private int m_ShipsToSpawn;
     
    public Mission(GameObject uiMissionInstance, int reward, int shipsToSpawn)
    {
        m_Reward = reward;
        m_UIMissionInstance = uiMissionInstance;
        m_ShipsToSpawn = shipsToSpawn;
    }

    public bool IsComplete()
    {
        if (!m_IsAccepted) return false;

        return m_TrackedEnemies.Count == 0;
    }

    public void AcceptMission()
    {
        m_IsAccepted = true;
        m_TrackedEnemies = new List<GameObject>();

        // Select a random spawn point
        int randomIndex = UnityEngine.Random.Range(0, MissionManager.s_Instance.m_SpawnPoints.Length);

        for (int i = 0; i < m_ShipsToSpawn; i++)
        {
            Transform randomSpawnPoint = MissionManager.s_Instance.m_SpawnPoints[randomIndex];

            bool positionFound = false;
            Vector3 position = Vector3.zero;
            Quaternion rotation = randomSpawnPoint.rotation;
            float radius = 30f;

            // Try to find a suitable spawn position
            while (!positionFound)
            {
                // Generate a random offset within the specified radius
                Vector3 randomOffset = UnityEngine.Random.insideUnitSphere * radius;
                randomOffset.y = 0; // Keep the offset on the XZ plane

                // Calculate the new position with the random offset
                position = randomSpawnPoint.position + randomOffset;

                // Check for existing objects with the "Enemy" tag within the radius
                Collider[] colliders = Physics.OverlapSphere(position, radius);
                bool overlap = false;

                foreach (var collider in colliders)
                {
                    if (collider.CompareTag("Enemy"))
                    {
                        overlap = true;
                        break;
                    }
                }

                if (!overlap)
                {
                    positionFound = true;
                }
            }

            // Instantiate the enemy ship at the new position and rotation
            var go = Object.Instantiate(MissionManager.s_Instance.m_EnemyShipPrefab, position, rotation);

            // Add the instantiated ship to the list
            m_TrackedEnemies.Add(go);
        }
    }
}
