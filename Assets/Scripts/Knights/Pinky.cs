using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pinky : Enemy
{
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
         if(canExit) pinkyPersonality();
    }

    private void pinkyPersonality()
    {
        if (!roaming && !frightenedState) navMeshAgent.SetDestination(target.transform.position);
        if (navMeshAgent.velocity.normalized.magnitude > 0.1f)
        {
            anim.SetFloat("Speed", navMeshAgent.velocity.normalized.magnitude);
        }
    }
}
