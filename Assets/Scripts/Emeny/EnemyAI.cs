using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float turnSpeed = 5f;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;

    private const string moveAnimationTrigger = "move";
    private const string attackAnimationBool = "attack";

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        EnemyBehavior();
    }

    private void EnemyBehavior()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        animator.SetBool(attackAnimationBool, false);
        animator.SetTrigger(moveAnimationTrigger);
        navMeshAgent.SetDestination(target.transform.position);
    }

    private void AttackTarget()
    {
        animator.SetBool(attackAnimationBool, true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
