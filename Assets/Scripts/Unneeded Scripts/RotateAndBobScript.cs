using System;
using System.Collections;
using UnityEngine;

public class RotateAndBobScript : MonoBehaviour
    {
    /// <summary>
    /// I found this script online, and I ended up using the target position portion of it in my rotate script,
    /// which I use on the coins and mines. I modified it very slightly on the Rotate script in order to add a randomness to the starting position
    /// so as to make sure that there was a certain degree of difference between the coins.
    /// </summary>
    public Vector3 bobAmount, rotateAmount, bobSpeed, rotateSpeed;
    private Vector3 startPos, startRot, targetPos, targetRot;
    void Start()
        {
        startPos = transform.localPosition;
        startRot = transform.localEulerAngles;
        }

    void Update()
        {
        targetPos = new Vector3(startPos.x + (bobAmount.x * Mathf.Sin(Time.time * bobSpeed.x)),
                                startPos.y + (bobAmount.y * Mathf.Sin(Time.time * bobSpeed.y)),
                                startPos.z + (bobAmount.z * Mathf.Sin(Time.time * bobSpeed.z)));

        targetRot = new Vector3(startRot.x + (rotateAmount.x * Mathf.Sin(Time.time * rotateSpeed.x)),
                                startRot.y + (rotateAmount.y * Mathf.Sin(Time.time * rotateSpeed.y)),
                                startRot.z + (rotateAmount.z * Mathf.Sin(Time.time * rotateSpeed.z)));

        transform.localEulerAngles = targetRot;
        transform.localPosition = targetPos;


        }
    }
