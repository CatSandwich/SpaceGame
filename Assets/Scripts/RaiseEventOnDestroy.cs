using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        MissionManager.s_Instance.RaiseOnEnemyDestroyed(this.gameObject);
    }
}
