using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.Events;

[RequireComponent(typeof(Enemy))]
public class MeleeEnemy : MonoBehaviour
{
    public Enemy enemy;
    public AIDestinationSetter destinationSetter;
    public float damageAmount;
    [Space]
    public UnityEvent onAttackHit;

    private Health playerHealth;
    private Animator anim;
    private AIPath agent;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        playerHealth = enemy.playerTransform.GetComponent<Health>();
        anim = GetComponent<Animator>();
        agent = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();

        destinationSetter.target = enemy.playerTransform;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, enemy.playerTransform.position);
        if(distanceFromPlayer >= enemy.attackingRange)
        {
            //Vector3 movDir = enemy.playerTransform.position - transform.position;
            //transform.Translate(movDir * Time.deltaTime);
            agent.canMove = true;
            anim.SetBool("isAttacking", false);
        } else
        {
            agent.canMove = false;
            //Do an attacking animation:
            anim.SetBool("isAttacking", true);
        }
    }

    //This is used by the animation event attached!
    public void AttackPlayer()
    {
        playerHealth.Damage(damageAmount);
        onAttackHit.Invoke();
    }
}
