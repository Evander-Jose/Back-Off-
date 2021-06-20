using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBehavior : MonoBehaviour
{
    public bool reflectInCursorDirection = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Projectile projectileComponent = collision.gameObject.GetComponent<Projectile>();
        if(projectileComponent)
        {
            Vector2 hitNormal = collision.contacts[0].normal;
            Vector2 oldVelocity = projectileComponent.rb2d.velocity;

            Vector2 newVelocity = Vector2.zero;

            if (reflectInCursorDirection == false)
                newVelocity = Vector2.Reflect(oldVelocity, hitNormal);
            else
                newVelocity = transform.up;

            projectileComponent.rb2d.velocity = newVelocity.normalized * projectileComponent.speed;

            projectileComponent.MarkProjectileAsReflected();
        }
    }
}
