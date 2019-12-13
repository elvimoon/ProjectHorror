using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public float WalkRadius = 40.0f;
    private Animator animator;

    Transform target;
    NavMeshAgent agent;
    void Start()
    {
        target = PlayerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
  
    }


    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= WalkRadius)
        {
            agent.SetDestination(target.position);
            animator.SetFloat("Speed", agent.speed);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, WalkRadius);
    }
}
