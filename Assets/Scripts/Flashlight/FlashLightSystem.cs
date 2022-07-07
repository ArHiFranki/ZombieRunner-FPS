using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] private float lightDecay = 0.1f;
    [SerializeField] private float angleDecay = 1f;
    [SerializeField] private float minAngle = 40f;

    private Light myLight;

    private void Awake()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle > minAngle)
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
