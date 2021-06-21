using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;
    public UnityEvent onProjectileLaunch;

    public void SpawnThenLaunchProjectile(Vector3 target)
    {
        GameObject newProjectile = Instantiate(projectile);
        Projectile projectileComponent = newProjectile.GetComponent<Projectile>();
        if (projectileComponent)
        {
            onProjectileLaunch.Invoke();
            projectileComponent.LaunchProjectile(target - transform.position, transform.position);
        }
    }
}
