using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    [SerializeField] public float detectionRadius = 10f;
    [SerializeField] public float stoppingDistance = 2f;

    private NavMeshAgent navMeshAgent;
    private bool isChasing = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); //calculate the distance btw player and enemy

        if (distanceToPlayer <= detectionRadius && !IsPlayerLookingAtEnemy())
        {
            StartChasing();
        }
        else if (isChasing && distanceToPlayer > stoppingDistance)
        {
            ContinueChasing();
        }
        else if (isChasing && distanceToPlayer <= stoppingDistance)
        {
            StopChasing();
        }

        if (IsPlayerLookingAtEnemy())
        {
            StopChasing();
        }
    }

    void StartChasing()
    {
        isChasing = true;
        navMeshAgent.isStopped = false; //ensures the navemesh agent is active
        navMeshAgent.SetDestination(player.position);
    }

    void ContinueChasing()
    {
        navMeshAgent.SetDestination(player.position); //upadting enemy position to player position
    }

    void StopChasing()
    {
        isChasing = false;
        navMeshAgent.isStopped = true; //stops the navmesh from moving
    }

    bool IsPlayerLookingAtEnemy()
    {
        Vector3 directionToEnemy = (transform.position - player.position).normalized; //calculated aa vector pointing from player to enemy
        //normalizing is important to ensure consistent comparison regardless of the distance between the player and the enemy.
        float dotProduct = Vector3.Dot(player.forward, directionToEnemy); //all meth bs to tell if player is looking at enemy or not

        if (dotProduct > 0.5f) // Adjust this value to fine-tune sensitivity
        {
            return true;
        }
        return false;
    }
    void OnDrawGizmosSelected() //for the outline circle thingy
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}