using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [Header("Movement")]
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public float movementSpeed;

    [HideInInspector] public Rigidbody2D RB;
    [HideInInspector] public Animator animator;

    SkeletonState currentState;
    SkeletonStateInstances instances;


    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        instances = new SkeletonStateInstances(this);

        currentState = instances.Patrol;
        currentState.EnterState();
    }

    void Update()
    {
        currentState.UpdateState();
    }

    void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    public void SetNextState(SkeletonState state)
    {
        currentState.ExitState();
        currentState = state;
        currentState.EnterState();
    }
}
