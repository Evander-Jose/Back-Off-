﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{
    public float damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        Health otherHealth = collision.gameObject.GetComponent<Health>();
        if(otherHealth)
        {
            //If there is a health component on the other gameobject, damage it:
            otherHealth.Damage(damageAmount);
        }
    }
}