using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Camera mainCamera;
    public float vitesseRotation = 5.0f;
    public float angleMaxVertical = 45.0f;

    void Update()
    {
        float rotationHorizontal = Input.GetAxis("Mouse X") * vitesseRotation;
        transform.Rotate(0, rotationHorizontal, 0);

        float rotationVertical = Input.GetAxis("Mouse Y") * vitesseRotation;
        float angleVertical = mainCamera.transform.rotation.eulerAngles.x;
        angleVertical = Mathf.Abs(angleVertical) > 180 ? 360 - Mathf.Abs(angleVertical) : Mathf.Abs(angleVertical);
        angleVertical -= rotationVertical;
        angleVertical = Mathf.Clamp(angleVertical, -angleMaxVertical, angleMaxVertical);
        mainCamera.transform.rotation = Quaternion.Euler(angleVertical, transform.rotation.eulerAngles.y, 0);
    }
}
