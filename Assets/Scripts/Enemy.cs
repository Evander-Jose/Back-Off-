using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileLauncher))]
public class Enemy : MonoBehaviour
{
    public float attackingRange;
    public float movementSpeed;
    public float attackDelay = 0.7f;
    private Transform playerTransform;
    private ProjectileLauncher projectileLauncher;

    private void OnEnable()
    {
        projectileLauncher = GetComponent<ProjectileLauncher>();
        playerTransform = FindObjectOfType<PlayerInput>().transform;
        projectileLauncher.playerTransform = playerTransform;
    }

    float timeSinceLastAttack = 0f;

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        if(distanceToPlayer > attackingRange)
        {
            //Approach the player if the enemy is outside attacking range:
            Vector3 directionTowardsPlayer = playerTransform.position - transform.position;
            
            //Normalize makes the magnitude of the direction vector 1 (avoids headaches)
            directionTowardsPlayer.Normalize();

            //Translation (move the transform's position):
            //Multiply the vector by Time.deltaTime to make sure that the object moves at n units per second, not n units per frame.
            transform.Translate(directionTowardsPlayer * Time.deltaTime * movementSpeed); 
        } else
        {
            //Attack the player repeatedly with a delay between each attack:
            if(timeSinceLastAttack > attackDelay)
            {
                timeSinceLastAttack = 0f;
                projectileLauncher.SpawnThenLaunchProjectile();
            }
        }

        timeSinceLastAttack += Time.deltaTime;
    }
}
