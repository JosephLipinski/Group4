using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FarmerAI : MonoBehaviour {

    public GameObject patrolPoint;
    NavMeshAgent agent;
    float moveSpeed = 10f;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolPoint.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector3.MoveTowards(transform.position, patrolPoint.transform.position, Time.deltaTime * moveSpeed);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PatrolPoint"){
            PatrolPoint _pp = other.gameObject.GetComponent<PatrolPoint>();
            patrolPoint = _pp.nextPatrolPoint;
            agent.SetDestination(patrolPoint.transform.position);
        }

    }
}
