using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Upgrades;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeData m_UpgradeData;
    [SerializeField] private TMP_Text m_UpgradeButtonText;


    // Update is called once per frame
    void Update()
    {
        m_UpgradeButtonText.text = $"{m_UpgradeData.Name} \n Level: {m_UpgradeData.Level + 1} / Cost:";
    }
}
