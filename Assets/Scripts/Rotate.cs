using System;
using System.Collections;
using UnityEngine;

public class Rotate : MonoBehaviour
    {
        public float rotateSpeed;
        public float upDownSpeed;
        public float distance;
         public float randomRange;
        public Vector3 bobAmount, bobSpeed;
        Vector3 startPosition, targetPosition;
        float randomTimeDifference;
        void Start()
            {
        startPosition = transform.localPosition;
            randomTimeDifference = UnityEngine.Random.Range(-randomRange,randomRange);
            transform.Rotate(new Vector3(0, randomTimeDifference * rotateSpeed * 10, 0));
            //transform.Translate(transform.position + new Vector3(0, randomTimeDifference, 0));
            
            }

        void Update()
        {
            transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime * 10);
        targetPosition = new Vector3(startPosition.x + (bobAmount.x * Mathf.Sin((Time.time + randomTimeDifference) * bobSpeed.x)),
                           startPosition.y + (bobAmount.y * Mathf.Sin((Time.time + randomTimeDifference) * bobSpeed.y)),
                           startPosition.z + (bobAmount.z * Mathf.Sin((Time.time + randomTimeDifference) * bobSpeed.z)));
        transform.localPosition = targetPosition;
        }
    }
