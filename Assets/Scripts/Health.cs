using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float currentHealth = 10f;
    [SerializeField] private float maximumHealth = 10f;
    public UnityEvent onDeath;
    public UnityEvent onDamaged;
    public float MaxHealth
    {
        get
        {
            return maximumHealth;
        }
    }

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }    

    public void Damage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0f)
        {
            onDeath.Invoke();
        } else
        {
            onDamaged.Invoke();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if(currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }
}
