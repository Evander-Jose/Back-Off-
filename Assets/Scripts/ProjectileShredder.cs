using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Projectile projectileComponent = other.GetComponent<Projectile>();
        if(projectileComponent)
        {
            Destroy(other.gameObject);
        }
    }
}
