using System;
using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip pickUpClip;
    public AudioClip mineHitClip;


    void Start()
	{
        BallController.OnPlaySound += PlaySound;
	}

    private void PlaySound(string name, Vector3 postition)
        {
        AudioClip source = ChooseSource(name);
        AudioSource.PlayClipAtPoint(source, postition);
        }

    private AudioClip ChooseSource(string name)
        {
        if (name == "CoinPickUp") return pickUpClip;
        if (name == "MineHit") return mineHitClip;
        return null;
        }

    void Update()
    {
        
    }
}
