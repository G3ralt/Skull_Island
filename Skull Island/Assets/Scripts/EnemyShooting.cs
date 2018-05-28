using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    private AggroDetection aggroDetection;
    private Health healthTarget;
    [SerializeField]
    private float attackRefreshRate = 1.5f;
    private float attackTimer;

    private void Awake() {

        aggroDetection = GetComponentInChildren<AggroDetection>();
        aggroDetection.OnAggro += Aggrodetection_OnAggro;


    }

    private void Aggrodetection_OnAggro(Transform target) {

        Health health = target.GetComponentInChildren<Health>();
        
        if ( health != null) {

            healthTarget = health;

        }

    }

    private void Update() {
        
        if ( healthTarget != null ) {

            attackTimer += Time.deltaTime;

            if (CanAttack()) {

                Attack();

            }

        }

    }

    private void Attack() {

        attackTimer = 0;
        healthTarget.TakeDamage(1);

    }

    private bool CanAttack() {

        return attackTimer >= attackRefreshRate;

    }
}
