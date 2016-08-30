using System;
using System.Collections;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpHeight;
    public AudioClip jumpSound;
    void OnCollisionEnter(Collision col)
        {
        Rigidbody rig = col.gameObject.GetComponent<Rigidbody>();
        if (rig != null)
            {
            rig.AddForce(Vector3.up * jumpHeight*100);
            SoundManager.instance.PlaySound(jumpSound, transform.position);
            }
        if (col.gameObject.CompareTag("Player"))
            {
            col.gameObject.GetComponent<BallController>().SetCanJump(true);
            }
        }
}
