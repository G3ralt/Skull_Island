using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private AggroDetection aggroDetection;

    private Transform target;

    private void Awake() {

        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        aggroDetection = GetComponentInChildren<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;

    }

    private void AggroDetection_OnAggro(Transform target) {

        this.target = target;

    }

    private void Update() {
        
        if ( target != null ) {

            navMeshAgent.SetDestination(target.position);
            float currentSpeed = navMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed", currentSpeed);

        }
        

    }
}
