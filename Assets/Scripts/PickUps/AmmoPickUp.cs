using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            Debug.Log("PickUp Ammo");
            Destroy(gameObject);
        }
    }
}
