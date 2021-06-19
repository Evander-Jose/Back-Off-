using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    //For testing purposes:
    public Transform playerTransform;
    public GameObject projectile;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnThenLaunchProjectile();   
        }
    }

    public void SpawnThenLaunchProjectile()
    {
        GameObject newProjectile = Instantiate(projectile);
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
        if (projectileComponent)
        {
            projectileComponent.LaunchProjectile(playerTransform.position - transform.position, transform.position);
        }
    }
}
