using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRateProgression : MonoBehaviour
{
    public FloatVariable spawnRateVariable;
    public IntVariable scoreCount;
    public float maxSpawnRate = 0.25f;
    public int killsUntilMax = 25;

    private float startingRate = 0f;
    private void Start()
    {
        startingRate = spawnRateVariable.CurrentValue;
    }

    private void Update()
    {
        spawnRateVariable.CurrentValue = Mathf.Lerp(startingRate, maxSpawnRate, (float)scoreCount.CurrentValue/killsUntilMax);
    }
}
