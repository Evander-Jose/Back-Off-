using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 3f;
    [Space]
    public UnityEvent onReflected;
    public UnityEvent onCollided;
    private bool isReflected;

    public bool IsReflected
    {
        get
        {
            return isReflected;
        }
    }

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void LaunchProjectile(Vector2 launchDir, Vector3 startPos)
    {
        transform.position = startPos;
        launchDir.Normalize();
        rb2d.velocity = launchDir * speed;
    }

    public void MarkProjectileAsReflected()
    {
        isReflected = true;
        onReflected.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onCollided.Invoke();
    }
}
