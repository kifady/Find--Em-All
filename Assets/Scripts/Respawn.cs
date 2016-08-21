using System;
using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject toRespawn;
    public int secondsToRespawn;

    Vector3 startPosition;
    void Start()
        {
        startPosition = transform.position;
        BallController.OnEnemyHit += RespawnTimer;
        }
    void RespawnTimer()
        {
        Invoke("RespawnGameObject", secondsToRespawn);
        }
    public void RespawnGameObject()
        {
        GameObject GO = Instantiate(toRespawn,startPosition,Quaternion.identity) as GameObject;
        GO.transform.parent = transform;
        transform.position = startPosition;
        
        }
}
