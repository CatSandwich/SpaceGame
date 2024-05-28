using Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarCalc : MonoBehaviour
{
    public BasicHealth m_Health;
    public Image m_HealthBarForeground;

    // Update is called once per frame
    void Update()
    {
        m_HealthBarForeground.fillAmount = (m_Health.Health / m_Health.MaxHealth);
    }
}
