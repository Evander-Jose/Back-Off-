using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(ProjectileLauncher))]
[RequireComponent(typeof(Enemy))]
public class RangedEnemy : MonoBehaviour
{
    public Enemy enemy;
    public AIDestinationSetter destinationSetter;

    float timeSinceLastAttack = 0f;
    private ProjectileLauncher launcher;
    private AIPath agent;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        launcher = GetComponent<ProjectileLauncher>();
        agent = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();

        destinationSetter.target = enemy.playerTransform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(enemy.playerTransform.position, transform.position);
        if(distanceToPlayer > enemy.attackingRange)
        {
            ////Approach the player if the enemy is outside attacking range:
            //Vector3 directionTowardsPlayer = enemy.playerTransform.position - transform.position;

            ////Normalize makes the magnitude of the direction vector 1 (avoids headaches)
            //directionTowardsPlayer.Normalize();

            ////Translation (move the transform's position):
            ////Multiply the vector by Time.deltaTime to make sure that the object moves at n units per second, not n units per frame.
            //transform.Translate(directionTowardsPlayer * Time.deltaTime * enemy.movementSpeed); 
            agent.canMove = true;
        } else
        {
            agent.canMove = false;
            //Attack the player repeatedly with a delay between each attack:
            if(timeSinceLastAttack > enemy.attackDelay)
            {
                timeSinceLastAttack = 0f;
                launcher.SpawnThenLaunchProjectile(enemy.playerTransform.position);
            }
        }

        timeSinceLastAttack += Time.deltaTime;
    }
}
