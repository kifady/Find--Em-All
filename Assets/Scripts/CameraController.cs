using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// This class is used to control the camera with the mouse.
/// The camera orbits around the player depending on the mouse movement.
/// </summary>

public class CameraController : MonoBehaviour
{
    public Vector3 originalOffset;
    public GameObject target;
    public float mouseSpeed;
    Vector3 offset;


    void Start()
        {
        offset = originalOffset;

        }
    void LateUpdate()
        {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSpeed, Vector3.up) * offset;
        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform);
        }

}
