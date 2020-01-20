﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjWithMouse : MonoBehaviour
{
    float rotationSpeed = 20f;

    private void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, -rotX);
        transform.Rotate(Vector3.right, rotY);

    }



}
