using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy : MonoBehaviour
{
    public float attackingRange;
    public float movementSpeed;
    public float attackDelay = 0.7f;
    public Transform playerTransform;
    [Space]
    public AIPath agent;
    public Animator anim;
    public string walkBoolName;

    private void OnEnable()
    {
        playerTransform = FindObjectOfType<PlayerInput>().transform;
    }

    //For the walking animation:
    private void Update()
    {
        anim.SetBool(walkBoolName, agent.canMove);
    }
}
