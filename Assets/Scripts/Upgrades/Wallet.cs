using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class Wallet : MonoBehaviour
{
    public TMP_Text m_MoneyText;
    private int m_Money = 0;

    private void Update()
    {
        m_MoneyText.text = $"${m_Money}";
    }

    public int GetMoney()
    {
        return m_Money;
    }

    public void AddMoney(int amount)
    {
        m_Money += amount;
        Debug.Log($"Added ${amount} to wallet for a total of {m_Money}");
    }
    
    public void RemoveMoney(int amount) 
    {
        m_Money -= amount;
        Debug.Log($"Subtracted ${amount} to wallet for a total of {m_Money}");
    }
}
