using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingAI : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Vector3 randomDestination;
    private bool isMoving = false;

    public float minIdleTime = 1f;
    public float maxIdleTime = 4f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        SetRandomDestination();
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f && !isMoving)
        {
            StartCoroutine(WaitAndSetDestination(Random.Range(minIdleTime, maxIdleTime)));
        }

        animator.SetFloat("IsWalking", navMeshAgent.velocity.magnitude);
    }

    void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);
        randomDestination = hit.position;
        navMeshAgent.SetDestination(randomDestination);
        isMoving = true;
    }

    System.Collections.IEnumerator WaitAndSetDestination(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SetRandomDestination();
        isMoving = false;
    }
}
