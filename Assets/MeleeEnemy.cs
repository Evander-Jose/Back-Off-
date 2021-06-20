using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class MeleeEnemy : MonoBehaviour
{
    public Enemy enemy;
    public float damageAmount;
    private Health playerHealth;
    private Animator anim;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        playerHealth = enemy.playerTransform.GetComponent<Health>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, enemy.playerTransform.position);
        if(distanceFromPlayer >= enemy.attackingRange)
        {
            Vector3 movDir = enemy.playerTransform.position - transform.position;
            transform.Translate(movDir * Time.deltaTime);
            anim.SetBool("isAttacking", false);
        } else
        {
            //Do an attacking animation:
            anim.SetBool("isAttacking", true);
        }
    }

    public void AttackPlayer()
    {
        playerHealth.Damage(damageAmount);
    }
}
