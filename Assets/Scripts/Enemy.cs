using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackingRange;
    public float movementSpeed;
    public float attackDelay = 0.7f;
    public Transform playerTransform;
    public ProjectileLauncher projectileLauncher;

    private void OnEnable()
    {
        projectileLauncher = GetComponent<ProjectileLauncher>();
        playerTransform = FindObjectOfType<PlayerInput>().transform;
        projectileLauncher.playerTransform = playerTransform;
    }

}
