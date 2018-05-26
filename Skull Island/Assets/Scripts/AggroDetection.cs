using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AggroDetection : MonoBehaviour {

    public event Action<Transform> OnAggro = delegate { };

    private void OnTriggerEnter(Collider other) {
        
        if ( other.tag.Equals("Player") ) {

            OnAggro(other.transform);
            GetComponent<NavMeshAgent>().SetDestination(other.transform.position);

        }

    }
}
