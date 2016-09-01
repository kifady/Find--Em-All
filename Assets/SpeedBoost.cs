using System;
using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

    public float speedBoost;

    public float multiplier = 1;
    public float maxMultiplier = 2.5f;

    float internalMultiplier = 60f;
    Rigidbody rig;


    private void AddMultiplier()
        {
        if (multiplier < maxMultiplier)
            {
            multiplier += 0.15f;
            print(multiplier);
            rig.AddForce(Vector3.forward * internalMultiplier / 2 * multiplier * speedBoost);
            }
        else
            {
            multiplier = maxMultiplier;
            Boost();
            }
        }

    void OnTriggerEnter(Collider col)
        {
        rig = col.gameObject.GetComponent<Rigidbody>();
        if (rig != null)
            {
            multiplier += 0.2f;
            InvokeRepeating("AddMultiplier", 0.2f, 0.2f);
            }
        }
    void OnTriggerExit(Collider col)
        {
        CancelInvoke("AddMultiplier");
        Boost();
        }

    private void Boost()
        {
        rig.AddForce(Vector3.forward * internalMultiplier * multiplier * speedBoost);
        multiplier = 1;
        }
    }
