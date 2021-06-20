using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{
    public float damageAmount;
    public bool destoryOnTriggerEnter = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Health otherHealth = collision.gameObject.GetComponent<Health>();
        if (otherHealth)
        {
            //If there is a health component on the other gameobject, damage it:
            otherHealth.Damage(damageAmount);
        }

        if(destoryOnTriggerEnter)
            Destroy(transform.parent.gameObject);
    }
}
