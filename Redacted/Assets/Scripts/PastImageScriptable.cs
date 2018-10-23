using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PastImageScriptable : ScriptableObject
{
    [SerializeField]
    private int MaxHealth;
    [SerializeField]
    private int CurrentHealth;
    
    public int Health
    {
        get { return CurrentHealth; }
    }

    bool IsAlive
    {
        get { return CurrentHealth > 0; }
    }

    void SetUp()
    {
        CurrentHealth = MaxHealth;
    }
    
    void TakeDamage()
    {
        CurrentHealth--;
    }
}
