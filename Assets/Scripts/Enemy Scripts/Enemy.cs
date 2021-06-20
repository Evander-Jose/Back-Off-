using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackingRange;
    public float movementSpeed;
    public float attackDelay = 0.7f;
    public Transform playerTransform;
    private void OnEnable()
    {
        playerTransform = FindObjectOfType<PlayerInput>().transform;
    }

}
