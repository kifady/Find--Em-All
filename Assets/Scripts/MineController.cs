using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// This class controls the behaviour of mines. 
/// </summary>

public class MineController : MonoBehaviour
{
    public delegate void SetToRespawn(GameObject gameObj);
    public static event SetToRespawn OnSetToRespawn;

    public Transform[] wayPoints;
    public float explosionForce = 25f;
    public ParticleSystem explosionParticles;
    public AudioClip explosionClip;
    void OnEnable()
        {
        explosionParticles.Stop();
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;

        }

    public void DestroyMine()
        {
        explosionParticles.Play();
        SoundManager.instance.PlaySound(explosionClip, transform.position);
        ObjectsToRespawn.instance.ToRespawn(gameObject);
        print("Destroy Mine Set Respawn");
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Invoke("DisableMine", explosionParticles.duration + 0.3f);
        }

    private void DisableMine()
        {
        explosionParticles.Stop();
        gameObject.SetActive(false);
        
       /* if (OnSetToRespawn != null)
            {
            OnSetToRespawn(gameObject);
            }*/
        }

    public float GetExplosionForce()
        {
        return explosionForce;
        }


    void OnCollisionEnter(Collision col)
        {
        DestroyMine();
        if (col.gameObject.CompareTag("Player"))
            {
            col.gameObject.GetComponent<BallController>().TriggerRespawn(explosionParticles.duration);
            col.gameObject.GetComponent<BallController>().TriggerExplosionForce(explosionForce,transform.position);
            }
        }

}
