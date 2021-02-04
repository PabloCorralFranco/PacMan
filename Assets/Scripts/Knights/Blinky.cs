using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Blinky : Enemy
{
    void FixedUpdate()
    {
        blinkyPersonality();
    }
    private void blinkyPersonality()
    {
        if (!roaming && !frightenedState) { navMeshAgent.SetDestination(target.transform.position); Debug.Log("No estoy asustado"); }
        if (navMeshAgent.velocity.normalized.magnitude > 0.1f)
        {
            anim.SetFloat("Speed", navMeshAgent.velocity.normalized.magnitude);
        }
    }
}
