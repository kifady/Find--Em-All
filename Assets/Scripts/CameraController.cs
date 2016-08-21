using System;
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 originalOffset;
    public GameObject target;
    public float mouseSpeed;
    Vector3 offset;


    void Start()
        {
        //        offset = target.transform.position + transform.position + originalOffset;
        offset = originalOffset;
        }
    void LateUpdate()
    {

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSpeed, Vector3.up) * offset;
        transform.position = target.transform.position + offset;
       // transform.RotateAround(target.transform.position + transform.position, Vector3.up, Input.GetAxis("Mouse X") * mouseSpeed);
        transform.LookAt(target.transform);
        }
}
