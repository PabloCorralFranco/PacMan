using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Clyde : Enemy
{
    //PUBLIC VARIABLES
    public float scatterDistance;
    
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        roaming = false;
        StartCoroutine("waitingTime", timeToWait);
    }
    void FixedUpdate()
    {
        if(canExit) clydePersonality();
    }

    private void clydePersonality()
    {
        float distanceToTarget = (transform.position - target.position).magnitude;
        if (distanceToTarget > scatterDistance && !roaming && !frightenedState)
        {
            navMeshAgent.SetDestination(target.transform.position);
        }
        if (navMeshAgent.velocity.normalized.magnitude > 0.1f)
        {
            anim.SetFloat("Speed", navMeshAgent.velocity.normalized.magnitude);
        }
    }
}
