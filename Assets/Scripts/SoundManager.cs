using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// This sound manager is used to control the sound effects in the game.
/// </summary>

public class SoundManager : MonoBehaviour
{
    public float lowPitchRange = 0.95f;
    public float highPitchRange = 1.05f;
    public AudioSource efxSource;                  
    public AudioSource musicSource;

    public AudioClip pickUpClip;
    public AudioClip mineHitClip;
    public AudioClip jumpPad;
    public AudioClip finish;

    public static SoundManager instance = null;
    void Awake()
	{
        if(instance == null)
                //if not, set it to this.
                instance = this;
            //If instance already exists:
            else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        BallController.OnPlaySound += PlaySound;
	}

    public void RandomizeSfx(params AudioClip[] clipArray)
        {
        float pitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);
        int index = UnityEngine.Random.Range(0, clipArray.Length - 1);

        AudioClip clipToPlay = clipArray[index];

        efxSource.pitch = pitch;
        efxSource.clip = clipToPlay;
        efxSource.Play();
        }
   
    private void PlaySound(string name, Vector3 postition)
        {
        AudioClip source = ChooseSource(name);
        AudioSource.PlayClipAtPoint(source, postition);
        }
    public void PlaySound(AudioClip clipToPlay, Vector3 position)
        {
        RandomizeSfx(clipToPlay);
        }



    private AudioClip ChooseSource(string name)
        {
        if (name == "CoinPickUp") return pickUpClip;
        if (name == "MineHit") return mineHitClip;
        if (name == "JumpPad") return jumpPad;
        if (name == "Finish") return finish;
        return null;
        }

    void OnDisable()
    {
        BallController.OnPlaySound -= PlaySound;
    }
}
