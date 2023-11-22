using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostController : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform targetTransform;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        StartCoroutine(SearchTarget());
    }

    IEnumerator SearchTarget()
    {
        agent.SetDestination(targetTransform.position);
        yield return new WaitForSeconds(3f);
    }
}
