using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 30f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name);

            // ToDo: Add some hit effect for visual players

            if (hit.transform.TryGetComponent(out EnemyHealth target))
            {
                target.TakeDamage(damage);
            }

            //EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            // call a method on EnemyHealth that decreases the enemy's health
        }
        else
        {
            return;
        }
    }
}
