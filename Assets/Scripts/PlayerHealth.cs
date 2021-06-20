using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Health playerHealthComponent;
    public FloatVariable playerHealthVariable;
    public FloatVariable playerMaxHealthVariable;

    private void Update()
    {
        playerHealthVariable.CurrentValue = playerHealthComponent.CurrentHealth;
        playerMaxHealthVariable.CurrentValue = playerHealthComponent.MaxHealth;
    }
}
