using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform Player; // Fetches the GameObject "Player"
    NavMeshAgent agent; // Fetches the NavMeshAgent agent
    [SerializeField] float patrolRadius; // Creates a float called "patrolRadius"

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Fetches the NavMeshAgent on startup
    }

    private void Update()
    {
        if (CanSeePlayer()) // If the AI can see the player, the following will occur
        {
            agent.SetDestination(Player.position); // Sets the AI's position to the position of the player
        }
        else
        {
            if(agent.remainingDistance <= 1) // If the AI can not see the player, it will set the distance to less than one and the following will occur
            {
                agent.SetDestination(RandomPoint(patrolRadius)); // Sets a random point from the "patrolRadius" float
            }
        }
    }

    Vector3 RandomPoint(float patrolRadius) // When this function is called, the following shall occur
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius; // Creates a sphere which the player cannot see but instead allows the AI to know where it can and cannot go
        randomDirection += transform.position; // Fetches a random direction by allowing it to choose a random position
        NavMeshHit hit; // Fetches the NavMeshHit hit
        Vector3 finalPosition = Vector3.zero; // Sets the finalposition of the AI to 0
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1)) // When the sample position is hit, the patrol radius is set to 1
        {
            finalPosition = hit.position; // When the finalPosition is reached, the hit is called
        }
        return finalPosition;
    }

    bool CanSeePlayer() // When this function is called, the following shall occur
    {
        RaycastHit hit; // Calls a RaycastHit hit
        Vector3 playerpos = Player.position + new Vector3(0, 0, 0); // Sets the playerpos vector to 0, 0, 0
        Vector3 dir = (playerpos - transform.position); // takes the position from the playerpos
        Debug.DrawRay(transform.position, dir, Color.red); // Draw a line for the distance of how far the player is from the AI
        if (Physics.Raycast(transform.position, dir, out hit, Mathf.Infinity)) // Finds a GameObject with a tag "Player" when the AI is active
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
