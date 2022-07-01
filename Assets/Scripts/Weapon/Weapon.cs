using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private float range = 100f;
    [SerializeField] private float damage = 30f;
    [SerializeField] private float timeBetweenShots = 0.5f;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    private bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);

            if (hit.transform.TryGetComponent(out EnemyHealth target))
            {
                target.TakeDamage(damage);
            }
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
