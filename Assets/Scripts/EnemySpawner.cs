using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public FloatVariable spawnRate;
    public FloatVariable rollRate;

    private void Start()
    {
        InvokeRepeating("RandomlySpawnEnemies", rollRate.CurrentValue, rollRate.CurrentValue);
    }

    private void RandomlySpawnEnemies()
    {
        Debug.Log("Randomly spawning!");
        if(Random.value <= spawnRate.CurrentValue)
        {
            GameObject enemyToSpawn = enemies[Random.Range(0, enemies.Count - 1)];
            GameObject newEnemy = Instantiate(enemyToSpawn, transform, true);
            newEnemy.transform.position = transform.position;
        }
    }
}
