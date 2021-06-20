using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemySpawn> enemies = new List<EnemySpawn>();
    public FloatVariable spawnRate;
    public FloatVariable rollRate;

    [System.Serializable]
    public class EnemySpawn
    {
        [Range(0f, 1f)] public float probability;
        public GameObject enemyPrefab;
    }

    private void Start()
    {
        InvokeRepeating("RandomlySpawnEnemies", rollRate.CurrentValue, rollRate.CurrentValue);
    }

    private void RandomlySpawnEnemies()
    {
        if(Random.value <= spawnRate.CurrentValue)
        {
            GameObject enemyToSpawn = GetRandomEnemy();
            GameObject newEnemy = Instantiate(enemyToSpawn, transform, true);
            newEnemy.transform.position = transform.position;
        }
    }

    private GameObject GetRandomEnemy()
    {
        float sum = 0f;
        //First get the sum of all probabilities from the list:
        foreach(EnemySpawn e in enemies)
        {
            sum += e.probability;
        }

        float roll = Random.Range(0f, sum);
        foreach(EnemySpawn e in enemies)
        {
            if((roll -= e.probability) <= 0f)
            {
                return e.enemyPrefab;
            }
        }
        return null;
    }
}
