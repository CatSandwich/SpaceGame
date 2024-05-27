using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Wallet : MonoBehaviour
{
    private int m_Money = 0;

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
