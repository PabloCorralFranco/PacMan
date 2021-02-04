using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private Player player;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }
    void Update()
    {/*
        navMeshAgent.destination = player.transform.position;
        if(navMeshAgent.velocity.normalized.magnitude > 0.1f)
        {
            anim.SetFloat("Speed", navMeshAgent.velocity.normalized.magnitude);
        }
     */
    }
}
