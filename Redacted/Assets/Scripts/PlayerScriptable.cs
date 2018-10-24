using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerScriptable : ScriptableObject
{
    [SerializeField]
    private float MaxHealth;
    [SerializeField]
    private float CurrentHealth;

    public void SetUp()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage()
    {
        CurrentHealth--;
    }
    
    public bool IsDead()
    {
        return CurrentHealth <= 0;
    }
}
