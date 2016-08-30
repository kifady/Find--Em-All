using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// This class is used to control the ball movement, and what happens when it collides with something or enters a trigger.
/// </summary>

public class BallController : MonoBehaviour
    {
    [Range(-1, 0)] public float dotProductResult;
    [Range(0, 1)] public float originalVelocityScale;
    public float ballSpeed = 35f;
    public float maxBallSpeed = 55f;
    public float changeDirectionBoost = 10f;
    public float jumpHeight = 2f;
    public float friction = -2.5f;
    public float deathYLimit = -10f;
    public int lives = 3;
    public bool tutorialLevel = false;
    public bool jumpAllowed = true;
    public GameObject mainCamera;

    #region Delegates
    public delegate void CoinPickedUp();
    public static event CoinPickedUp OnCoinPickup;

    public delegate void EnemyHit();
    public static event EnemyHit OnEnemyHit;

    public delegate void LifeLost();
    public static event LifeLost OnLifeLost;
    public delegate void RespawnEvent();
    public static event RespawnEvent OnRespawn;

    public delegate void GameOver();
    public static event GameOver OnGameOver;

    public delegate void PlaySound(string name, Vector3 postition);
    public static event PlaySound OnPlaySound;

    public delegate void ReachedFinish(GameObject gameObj);
    public static event ReachedFinish OnReachFinish;
    #endregion


    Rigidbody ballRig;
    Vector3 spawn;
    bool canJump;

    public AudioClip coinPickupClip;
    public AudioClip finishClip;

    void Start()
        {
        ballRig = GetComponent<Rigidbody>();
        spawn = transform.position;
        canJump = jumpAllowed;
        }

 
    void Update()
        {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 direction = mainCamera.transform.TransformDirection(input).normalized;
        Vector3 directionXZ = new Vector3(direction.x, 0, direction.z);
        Vector3 velocity = directionXZ * ballSpeed * 10;

        if (lives <= 0 && !tutorialLevel)
            {
            if (OnGameOver != null)
                {
                OnGameOver();
                }
            }

        else if (transform.position.y <= deathYLimit)
            {
            LoseLife();
            Respawn();
            }

        else
            {
            if (Vector3.Dot(velocity.normalized, ballRig.velocity.normalized) <= dotProductResult)
                {
                
                ballRig.velocity.Set(ballRig.velocity.x / originalVelocityScale, ballRig.velocity.y, ballRig.velocity.z / originalVelocityScale);
                velocity = velocity * changeDirectionBoost;
                }
            if (ballRig.velocity.magnitude < maxBallSpeed)
                {
                ballRig.AddForce(velocity * Time.deltaTime, ForceMode.Force);
                }
            if (Input.GetButtonDown("Jump") && canJump)
                {
                ballRig.AddForce(new Vector3(0, jumpHeight * 2), ForceMode.Impulse);
                canJump = false;
                }
            }
        if (velocity == Vector3.zero)
            {
            ballRig.AddForce(new Vector3(ballRig.velocity.x, 0, ballRig.velocity.z) * friction);
            }
        }

    private void Respawn()
        {
        GetComponent<BallController>().enabled = true;
        ballRig.velocity = Vector3.zero;
        transform.position = spawn;
        ballRig.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        ObjectsToRespawn.instance.ReEnable(0.35f);
        }

    public void LoseLife()
        {
        lives--;
        if (OnLifeLost != null)
            {
            OnLifeLost();
            }
        }
    internal void TriggerRespawn(float duration)
        {
        LoseLife();
        Invoke("Respawn", duration);
        }
    internal void TriggerExplosionForce(float force, Vector3 explosionPos)
        {
        ballRig.AddExplosionForce(30f * force,explosionPos, 5f);
        }


    void OnCollisionEnter(Collision col)
        {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Platform"))
            {
            canJump = true;
            }
       /* if (col.gameObject.CompareTag("Mine"))
            {
            GameObject mine = col.gameObject;
            LoseLife();
            float force = mine.GetComponent<MineController>().GetExplosionForce();
            ballRig.AddExplosionForce(30f * force, mine.transform.position, 5f);
            if (OnPlaySound != null)
                {
                OnPlaySound("MineHit", mine.transform.position);
                }

            if (OnLifeLost != null)
                {
                OnLifeLost();
                }
            if (OnEnemyHit != null)
                {
                OnEnemyHit();
                }
            mine.GetComponent<MineController>().DestroyMine();
            Invoke("Respawn", mine.GetComponent<MineController>().explosionParticles.duration);
            }*/
        }

    void OnTriggerEnter(Collider col)
        {
        if (col.gameObject.CompareTag("Coin"))
            {
            if (OnCoinPickup != null)
                {
                OnCoinPickup();
                }
            SoundManager.instance.PlaySound(coinPickupClip, transform.position);

            Destroy(col.gameObject);
            }
        if (col.gameObject.CompareTag("Instruction"))
            {
            col.gameObject.GetComponent<Instruction>().ActivateText();
            }
        if (col.gameObject.CompareTag("Finish"))
            {
            if (OnReachFinish != null)
                {
                OnReachFinish(col.gameObject);
                }
            }
        
        }

    void OnTriggerExit(Collider col)
        {
        if (col.gameObject.CompareTag("Instruction"))
            {
            col.gameObject.GetComponent<Instruction>().DeactivateText();
            }
        if (col.gameObject.CompareTag("Finish"))
            {
            col.gameObject.GetComponent<Instruction>().DeactivateText();
            }
        }

    public void SetCanJump(bool jumpState)
        {
        canJump = jumpState;
        }

    }






