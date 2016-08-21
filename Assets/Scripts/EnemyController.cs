using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] wayPoints;
    public ParticleSystem explosionParticles;
	void Start()
	{     
        //explosionParticles = gameObject.GetComponent<ParticleSystem>();
        explosionParticles.Stop();
        }

    public void EnemyHit()
        {
        explosionParticles.Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Destroy(gameObject, explosionParticles.duration+0.5f);
        }

    void Update()
    {
        
    }
}
