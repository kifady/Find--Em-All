using System;
using System.Collections;
using UnityEngine;

public class RotateAndBobScript : MonoBehaviour
    {
    public Vector3 bobAmount, rotateAmount, bobSpeed, rotateSpeed;
    private Vector3 startPos, startRot, targetPos, targetRot;
    float randomTimeDifference;
    void Start()
        {
        startPos = transform.localPosition;
        startRot = transform.localEulerAngles;
        randomTimeDifference = UnityEngine.Random.Range(0, 1);
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
