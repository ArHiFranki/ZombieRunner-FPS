using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] float damage = 40f;

    public void AttackHitEvent()
    {
        if (target == null) return;
        Debug.Log("Bonk");
    }
}