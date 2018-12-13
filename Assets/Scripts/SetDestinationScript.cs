using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetDestinationScript : MonoBehaviour {
    NavMeshAgent agent;

    // Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
    public void set_destination(Vector3 pos) {
        if (agent.enabled) {
            agent.destination = pos;
        }
    }
}
