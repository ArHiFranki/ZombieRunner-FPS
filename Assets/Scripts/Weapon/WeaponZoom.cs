using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private float zoomInFOV = 25f;
    [SerializeField] private float zoomInSensitivity = 0.5f;
    [SerializeField] private RigidbodyFirstPersonController myFPSController;

    private float zoomOutFOV;
    private float zoomOutSensitivity;
    private bool isZoomIn = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Start()
    {
        zoomOutFOV = myCamera.fieldOfView;
        zoomOutSensitivity = myFPSController.mouseLook.XSensitivity;
    }

    private void Update()
    {
        ZoomController();
    }

    private void ZoomController()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isZoomIn)
            {
                ZoomOut();
            }
            else
            {
                ZoomIn();
            }
        }
    }

    private void ZoomIn()
    {
        isZoomIn = true;
        myCamera.fieldOfView = zoomInFOV;
        myFPSController.mouseLook.XSensitivity = zoomInSensitivity;
        myFPSController.mouseLook.YSensitivity = zoomInSensitivity;
    }

    private void ZoomOut()
    {
        isZoomIn = false;
        myCamera.fieldOfView = zoomOutFOV;
        myFPSController.mouseLook.XSensitivity = zoomOutSensitivity;
        myFPSController.mouseLook.YSensitivity = zoomOutSensitivity;
    }
}
