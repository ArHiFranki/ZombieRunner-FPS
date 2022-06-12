using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxPlayerHealth = 100f;

    private float currentPlayerHealth;

    private void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
    }

    public void TakeDamage(float damage)
    {
        currentPlayerHealth -= damage;
        if (currentPlayerHealth <= 0)
        {
            Debug.Log("You Died");
        }
    }
}
