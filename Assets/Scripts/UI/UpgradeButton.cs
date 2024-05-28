using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private UpgradeData m_UpgradeData;
    [SerializeField] private TMP_Text m_UpgradeButtonText;
    [SerializeField] private Wallet m_PlayerWallet;
    [SerializeField] private Image m_Image;
    [SerializeField] private Color m_MaxedColor;


    // Update is called once per frame
    void Update()
    {
        if (!m_UpgradeData.IsMaxed)
        {
            m_UpgradeButtonText.text = $"{m_UpgradeData.NextUpgradeName} \n Level: {m_UpgradeData.Level + 1}  -  Cost: {m_UpgradeData.CostToUpgrade}";
        }
        else
        { 
            m_Image.color = m_MaxedColor;
            m_UpgradeButtonText.text = $"{m_UpgradeData.Name} \n Level: MAXED";
        }

    }

    public void BuyUpgrade()
    {
        if (m_PlayerWallet == null) return;

        if (m_PlayerWallet.GetMoney() > m_UpgradeData.CostToUpgrade)
        {
            m_PlayerWallet.RemoveMoney(m_UpgradeData.CostToUpgrade);

            m_UpgradeData.Level++;
        }
    }
}
