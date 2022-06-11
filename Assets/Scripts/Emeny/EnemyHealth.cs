using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitpoints = 100f;

    private float currentHitPoints;

    private void Start()
    {
        currentHitPoints = hitpoints;
    }

    public void TakeDamage(float damage)
    {
        currentHitPoints -= damage;
        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
