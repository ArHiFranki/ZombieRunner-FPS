using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] private int ammoAmount = 5;
    [SerializeField] private AmmoType ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ammo playerAmmo))
        {
            playerAmmo.IncreaseCurrentAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
