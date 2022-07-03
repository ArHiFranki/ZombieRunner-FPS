using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitpoints = 100f;

    private float currentHitPoints;
    private Animator animator;
    private const string dieAnimationTrigger = "die";
    private bool isDead = false;

    public bool IsDead => isDead;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHitPoints = hitpoints;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        currentHitPoints -= damage;
        if (currentHitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        animator.SetTrigger(dieAnimationTrigger);
    }
}
