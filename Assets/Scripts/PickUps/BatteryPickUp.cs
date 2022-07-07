using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    [SerializeField] private float restoreAngle;
    [SerializeField] private float intensityAmount;

    private FlashLightSystem flashLightSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<FlashLightSystem>())
        {
            flashLightSystem = other.GetComponentInChildren<FlashLightSystem>();
            flashLightSystem.RestoreLightAngle(restoreAngle);
            flashLightSystem.AddLightIntensity(intensityAmount);
            Destroy(gameObject);
        }
    }
}
