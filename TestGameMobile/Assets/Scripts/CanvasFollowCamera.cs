using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollowCamera : MonoBehaviour
{
    public Camera mainCamera;

    void LateUpdate()
    {
        Vector3 targetPosition = transform.position + mainCamera.transform.rotation * Vector3.forward;
        Vector3 targetUp = mainCamera.transform.rotation * Vector3.up;
        transform.LookAt(targetPosition, targetUp);
    }
}
