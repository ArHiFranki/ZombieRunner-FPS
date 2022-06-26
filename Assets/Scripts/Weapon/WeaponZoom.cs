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
                myCamera.fieldOfView = zoomOutFOV;
                myFPSController.mouseLook.XSensitivity = zoomOutSensitivity;
                myFPSController.mouseLook.YSensitivity = zoomOutSensitivity;
            }
            else
            {
                myCamera.fieldOfView = zoomInFOV;
                myFPSController.mouseLook.XSensitivity = zoomInSensitivity;
                myFPSController.mouseLook.YSensitivity = zoomInSensitivity;
            }

            isZoomIn = !isZoomIn;
        }
    }
}
