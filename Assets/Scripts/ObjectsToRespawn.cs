using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsToRespawn : MonoBehaviour
{
    public List<GameObject> toRespawn;
    public static ObjectsToRespawn instance = null;

    void Awake()
        {
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);
        }

    void OnEnable()
        {
       // MineController.OnSetToRespawn += ToRespawn;
        //BallController.OnLifeLost += ReEnable;
       // BallController.OnRespawn += ReEnable;
        }

    void OnDisable()
        {
       // MineController.OnSetToRespawn -= ToRespawn;
        //        BallController.OnLifeLost -= ReEnable;
       // BallController.OnRespawn -= ReEnable;

        }

    public void ToRespawn(GameObject gameObj)
        {
        toRespawn.Add(gameObj);
        
        }
    public void ReEnable()
        {
        print("ObjectsToRespawn ReEnable");
        foreach (GameObject toEnable in toRespawn)
            {
            toEnable.SetActive(true);
            }
        }
    public void ReEnable(float delay)
        {
        Invoke("ReEnable", delay);
        }


    }
