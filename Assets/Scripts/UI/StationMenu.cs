using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationMenu : MonoBehaviour
{
    [SerializeField] private int m_InteractDistance;
    [SerializeField] private KeyCode m_InteractKey;
    [SerializeField] private KeyCode m_ExitKey;
    [SerializeField] private GameObject m_StationMenu;
    [SerializeField] private GameObject m_PlayerRef;


    void Update()
    {
        if (Input.GetKeyDown(m_InteractKey))
        {
            if (Vector3.Distance(transform.position, m_PlayerRef.transform.position) <= m_InteractDistance)
            {
                m_StationMenu.SetActive(true);
            }
        }

        if (Input.GetKeyDown(m_ExitKey))
        {
            m_StationMenu.SetActive(false);
        }
    }
}