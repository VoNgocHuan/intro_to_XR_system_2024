using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private bool isWalking = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Start the walking coroutine
        StartCoroutine(WalkRandomDestination());
    }

    void Update()
    {
        // Set animation parameter based on whether the AI is walking
        animator.SetBool("IsWalking", isWalking);
    }

    IEnumerator WalkRandomDestination()
    {
        while (true)
        {
            // Generate a random direction within the forward vector
            Vector3 randomDirection = transform.forward * Random.Range(5f, 15f);

            // Set the destination for the NavMeshAgent
            agent.SetDestination(transform.position + randomDirection);

            // Set isWalking to true to trigger walking animation
            isWalking = true;

            // Wait for the AI to reach the destination
            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance < 0.1f);

            // Set isWalking to false to trigger idle animation
            isWalking = false;

            // Wait for a short period before generating the next random destination
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }
}
