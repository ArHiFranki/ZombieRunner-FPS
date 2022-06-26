using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private float zoomInFOV = 25f;
    
    private float zoomOutFOV;
    private bool isZoomIn = false;

    private void Start()
    {
        zoomOutFOV = myCamera.fieldOfView;
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
            }
            else
            {
                myCamera.fieldOfView = zoomInFOV;
            }

            isZoomIn = !isZoomIn;
        }
    }
}
