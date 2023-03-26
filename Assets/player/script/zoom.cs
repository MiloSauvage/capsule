using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomFOV = 30f;
    public float defaultFOV = 60f;
    public float zoomSpeed = 5f;
    private bool isZooming = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isZooming = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isZooming = false;
        }

        if (isZooming)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, zoomFOV, zoomSpeed * Time.deltaTime);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, defaultFOV, zoomSpeed * Time.deltaTime);
        }
    }
}



