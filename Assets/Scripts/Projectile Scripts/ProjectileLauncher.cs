using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;

    public void SpawnThenLaunchProjectile(Vector3 target)
    {
        GameObject newProjectile = Instantiate(projectile);
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
        if (projectileComponent)
        {
            projectileComponent.LaunchProjectile(target - transform.position, transform.position);
        }
    }
}
